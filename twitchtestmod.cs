using Steamworks;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace twitchtestmod
{
	public class twitchtestmod : Mod
	{
		//required
		TwitchInput test = new TwitchInput();
		public static Mod ProjectT;

		//for shop
		public static List<TItem> Itemlist = new List<TItem>();
		public static List<TNPC> NPClist = new List<TNPC>();
		public static List<TBuff> Bufflist = new List<TBuff>();


		//theoretically not required
		public static twitchtestmod instance;

		public override void Load()
		{
			ProjectT = ModLoader.GetMod("ProjectT");
			instance = this;
		}

		public override void Unload()
		{
			ProjectT = null;
			Itemlist = null;
			NPClist = null;
			Bufflist = null;
			instance = null;
		}
		//Code from here on is for the shop

		public override void PostAddRecipes()
		{
			Commands.CConfig = ModContent.GetInstance<commandconfig>();
			initconfig();
		}

		public static bool menucheck()
		{
			return Main.gameMenu;
		}

		public static bool DoesItemexist(string name, out int ID)
		{
			var item = Itemlist.Find((i) => i.Name.ToLower() == name);

			if (item != null)
			{
				ID = item.ID;
				return true;
			}
			ID = 0;
			return false;
		}

		public static bool DoesNPCexist(string name, out int ID)
		{
			var item = NPClist.Find((i) => i.Name.ToLower() == name);

			if (item != null)
			{
				ID = item.ID;
				return true;
			}

			ID = 0;
			return false;
		}

		public static bool DoesBuffexist(string name, out TBuff Buff)
		{
			var item = Bufflist.Find((i) => i.Name.ToLower() == name);

			if (item != null)
			{
				Buff = item;
				return true;
			}

			Buff = null;
			return false;
		}

		public void initconfig()
		{
			priceconfig.CheckifExist();
			//reading the config
			Itemlist = priceconfig.getItemConfig();
			NPClist = priceconfig.getNPCConfig();
			Bufflist = priceconfig.getBuffConfig();
			//remaking the lists to make sure IDs are still up to date, just keeping prices. (IDs are "reshuffled" for Moditems everytime you change your modlist)
			Itemlist = priceconfig.HardRepopulateItems(Itemlist);
			NPClist = priceconfig.HardRepopulateNPCs(NPClist);
			//Bufflist doesn't need repopulating just yet.
			//write the "up to date" lists back to the configfiles.
			priceconfig.OverwriteItemConfig(Itemlist);
			priceconfig.OverwriteNPCConfig(NPClist);
			//no need to rewrite the config if nothing was changed.
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			NetworkHandlers.HandleIncommingData(reader, whoAmI);
		}
	}
}