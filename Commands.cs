using Microsoft.Xna.Framework;
using ProjectT;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace twitchtestmod
{
    public static class Commands
    {
        public static Config TConfig = new Config();
        public static commandconfig CConfig = new commandconfig();
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
                //if multiplayerclient, we can't spawn it ourselfes. so give it to the server.
                if(Main.netMode == NetmodeID.MultiplayerClient)
                {
                    MainNetworking.NPCAddToQueue(NPCType, count, viewer.Name);
                    Calls.sendmessage("@" + viewer.Name + " Your " + count + " " + npc.FullName + "(s) will be spawned");
                    return;
                }

                if (npc.townNPC)
                {
                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        NPC anpc = Main.npc[i];
                        if (npc.type == anpc.type)
                        {
                            npc.Teleport(Main.player[Main.myPlayer].position, 1);
                            return;
                        }
                    }
                }

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
                    //NPC.NewNPC(posx, posy, NPCType);
                    //Main.npc[NPC.NewNPC(posx, posy, NPCType)].netUpdate = true;
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
                Calls.sendmessage("@" + viewer.Name + " you don't have enough Coins for this NPC - it costs " + cost);
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
            double cost = item.value * count;
            if (Calls.removecoins(viewer, Convert.ToDouble(cost)))
            {
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    MainNetworking.ItemAddToQueue(ItemType, count);
                    Calls.sendmessage("@" + viewer.Name + " Your " + count + " " + item.Name + "(s) will be spawned");
                    return;
                }

                Item.NewItem(Main.player[Main.myPlayer].getRect(), ItemType, count, false, -1, false, false);

                if (TConfig.ChatBuyAlert)
                {
                    Main.NewText(viewer.Name + " has bought " + count + " " + item.Name, Color.Red);
                }
                Calls.sendmessage("@" + viewer.Name + " Your " + count + " " + item.Name + "(s) have/has been spawned");
            }
            else
            {
                Calls.sendmessage("@" + viewer.Name + " you don't have enough Coins for this Item - it costs " + cost);
            }
        }

        public static void BuyPotionEffectCommand(Viewer viewer, TBuff Buff, int seconds)
        {
            if (TConfig.disableBuffs) { return; }
            double cost = 0;
            cost = Buff.Price * seconds;
            if (Calls.removecoins(viewer, cost))
            {
                /*if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    MainNetworking.BuffAddToQueue(Buff.ID, seconds);
                    Calls.sendmessage("@" + viewer.Name + " Your " + seconds + " seconds of " + Buff.Name + " will be applied");

                    return;
                }*/

                int duration = seconds * 60;

                Main.player[Main.myPlayer].AddBuff(Buff.ID, duration);

                if (TConfig.ChatBuyAlert)
                {
                    Main.NewText(viewer.Name + " has bought " + seconds + " seconds of " + Buff.Name + " Buff/Debuff", Color.Red);
                }
                Calls.sendmessage("@" + viewer.Name + " Your " + seconds + " seconds of " + Buff.Name + " have been applied");
            }
            else
            {
                Calls.sendmessage("@" + viewer.Name + " you don't have enough Coins for this Buff - it costs " + cost);
            }
        }

        public static void BuyBuffEffectGlobalEnemies(Viewer viewer, TBuff Buff, int seconds)
        {
            /*
            if(TConfig.disableGlobalBuffs) { return; }
            double cost = 0;
            cost = Buff.Price * seconds;
            */
        }
	}
}
