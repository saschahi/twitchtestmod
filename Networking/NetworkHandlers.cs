using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace twitchtestmod
{
    public static class NetworkHandlers
    {
        public static void HandleIncommingData(BinaryReader Reader, int WhoAmI)
        {
            MessageTypes.MessageType msgType = (MessageTypes.MessageType)Reader.ReadByte();
            switch (msgType)
            {
                case MessageTypes.MessageType.SpawnNPC:
                    ProcessSpawnNPCRequest(Reader, WhoAmI);
                    break;
                case MessageTypes.MessageType.SpawnItem:
                    ProcessSpawnItemRequest(Reader, WhoAmI);
                    break;
                case MessageTypes.MessageType.ApplyBuff:
                    ProcessApplyBuffRequest(Reader, WhoAmI);
                    break;
                default:
                    break;
            }
        }

		private static void ProcessSpawnNPCRequest(BinaryReader reader, int playerNumber)
		{
			int npcType = reader.ReadInt32();
			NPC newNPC = new NPC();
			newNPC.SetDefaults(npcType);
            int amount = reader.ReadInt32();
            string name = reader.ReadString();
            //if townnpc exists, instead of spawning more, teleport townnpc to player
			if (newNPC.townNPC)
			{
				for (int i = 0; i < Main.npc.Length; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.type == newNPC.type)
					{
						npc.Teleport(Main.player[playerNumber].position, 1);
						return;
					}
				}
			}

            Random xrandomizer = new Random();
            int posx = (int)Main.player[playerNumber].position.X;
            int posy = (int)Main.player[playerNumber].position.Y;
            if (posy < 700)
            {
                posy = posy + 700;
            }
            else
            {
                posy = posy - 400;
            }

            for (int i = 0; i < amount; i++)
            {
                posx = (int)Main.player[playerNumber].position.X;
                posx = posx + xrandomizer.Next(-800, 800);
                if (posx < 0)
                {
                    posx = 0;
                }
                
                int change = NPC.NewNPC(posx, posy, npcType);
                if (name != null)
                {
                    Main.npc[change].GivenName = name;
                }
            }
            Main.NewText("Spawned " + amount + " " + newNPC.TypeName + " for " + Main.player[playerNumber].name);
		}

        private static void ProcessSpawnItemRequest(BinaryReader reader, int playerNumber)
        {
            int ItemType = reader.ReadInt32();
            int amount = reader.ReadInt32();
            
            Item.NewItem(Main.player[playerNumber].getRect(), ItemType, amount);
        }
        private static void ProcessApplyBuffRequest(BinaryReader reader, int playerNumber)
        {
            //no use for this lol...
            /*
            int BuffType = reader.ReadInt32();
            int amount = reader.ReadInt32();
            int seconds = amount * 60;

            Main.player[playerNumber].AddBuff(BuffType, seconds);
            */
        }

    }
}
