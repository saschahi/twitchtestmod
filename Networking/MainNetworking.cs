using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitchtestmod
{
    public static class MainNetworking
    {
		//just some "borrowed" code from Herosmod. for reals. Herosmod was written by a god. :)
		private static BinaryWriter Writer;
		private static MemoryStream memoryStream;
		
		public static void init()
		{
			memoryStream = new MemoryStream();
			Writer = new BinaryWriter(memoryStream);
		}
		public static void Unload()
		{
			Writer = null;
			memoryStream = null;
		}

		public static void NPCAddToQueue(int npcType, int amount, string name)
		{
			ResetWriter();
			Writer.Write((byte)MessageTypes.MessageType.SpawnNPC);
			Writer.Write(npcType);
			Writer.Write(amount);
			Writer.Write(name);
			SendPackets();
		}
		public static void ItemAddToQueue(int ItemType, int amount)
		{
			ResetWriter();
			Writer.Write((byte)MessageTypes.MessageType.SpawnItem);
			Writer.Write(ItemType);
			Writer.Write(amount);
			SendPackets();
		}
		public static void BuffAddToQueue(int BuffType, int seconds)
		{
			ResetWriter();
			Writer.Write((byte)MessageTypes.MessageType.ApplyBuff);
			Writer.Write(BuffType);
			Writer.Write(seconds);
			SendPackets();
		}

		private static void SendPackets()
		{
			var a = twitchtestmod.instance.GetPacket();
			a.Write(memoryStream.ToArray());
			a.Send();
			ResetWriter();
		}

		private static void ResetWriter()
		{
			if (memoryStream != null)
			{
				memoryStream.Close();
			}
			memoryStream = new MemoryStream();
			Writer = new BinaryWriter(memoryStream);
		}
	}
}
