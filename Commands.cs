﻿using Microsoft.Xna.Framework;
using ProjectT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace twitchtestmod
{
    public static class Commands
    {
        public static Config TConfig = new Config();

        public static void BuyNPCCommand(Viewer viewer, int NPCType, int count)
        {
            if(count > 100)
            {
                //just to prevent... a lot of things.
                count = 100;
            }
            NPC npc = new NPC();
            npc.SetDefaults(NPCType);
            double cost = 0;
            NPCDefinition test = new NPCDefinition(NPCType);
            if(TConfig.whitelistmodeNPC && !TConfig.BannedNPC.Contains(test) || !TConfig.whitelistmodeNPC && TConfig.BannedNPC.Contains(test) || TConfig.disableNPC || TConfig.disablebosses && npc.boss || TConfig.disabletownies && npc.townNPC)
            {
                return;
            }
            try
            {
                cost = npc.lifeMax * count;
                cost = cost + (npc.damage * count);
            }
            catch { return; }
            if (Calls.removecoins(viewer, Convert.ToDouble(cost)))
            {
                Random xrandomizer = new Random();
                int posx = (int)Main.player[Main.myPlayer].position.X;
                int posy = (int)Main.player[Main.myPlayer].position.Y;
                if (posy < 700)
                {
                    posy = posy + 700;
                }
                else
                {
                    posy = posy - 400;
                }
                
                for (int i = 0; i < count; i++)
                {

                    posx = (int)Main.player[Main.myPlayer].position.X;
                    posx = posx + xrandomizer.Next(-800, 800);
                    if (posx < 0)
                    {
                        posx = 0;
                    }

                    NPC.NewNPC(posx, posy, NPCType);
                }
                if (TConfig.ChatBuyAlert)
                {
                    Main.NewText(viewer.Name + " has bought " + count + " " + npc.FullName, Color.Red);
                }
                Calls.sendmessage("@" + viewer.Name + " Your " + count + " " + npc.FullName + "(s) have/has been spawned");
            }
            else 
            {
                Calls.sendmessage("@" + viewer.Name + " you don't have enough Coins for this NPC - it costs " + npc.lifeMax);
            }


        }
        public static void BuyItemCommand(Viewer viewer, int ItemType, int count)
        {
            Item item = new Item();
            item.SetDefaults(ItemType);
            ItemDefinition test = new ItemDefinition(ItemType);
            if (TConfig.whitelistmodeItems && !TConfig.BannedItems.Contains(test) || !TConfig.whitelistmodeItems && TConfig.BannedItems.Contains(test) || TConfig.disableItems)
            {
                return;
            }
            if(count > item.maxStack)
            {
                //just to prevent inventory nuking
                count = item.maxStack;
            }
            if (Calls.removecoins(viewer, Convert.ToDouble(item.value)))
            {
                for (int i = 0; i < count; i++)
                {
                    //shortversion: Spawn a new Item, at the location of myPlayer, that has the "type" of the item bought
                    Item.NewItem(Main.player[Main.myPlayer].getRect(), ItemType);
                }
                if (TConfig.ChatBuyAlert)
                {
                    Main.NewText(viewer.Name + " has bought " + count + " " + item.Name, Color.Red);
                }
                Calls.sendmessage("@" + viewer.Name + " Your " + count + " " + item.Name + "(s) have/has been spawned");

            }
            else
            {
                Calls.sendmessage("@" + viewer.Name + " you don't have enough Coins for this Item - it costs " + item.value);
            }
        }

        public static void BuyPotionEffectCommand(Viewer viewer, int type, int seconds)
        {
            






            Main.player[Main.myPlayer].AddBuff(type, seconds);
        }
	}
}