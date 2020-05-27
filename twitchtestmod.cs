using ProjectT;
using System.Collections.Generic;
using System.Linq;
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

		//theoretically not required
		public static twitchtestmod instance;

		public override void Load()
		{
			ProjectT = ModLoader.GetMod("ProjectT");
		}

		public override void Unload()
		{
			ProjectT = null;
			Itemlist = null;
			NPClist = null;
			
		}
		//Code from here on is for the shop

		public override void PostAddRecipes()
		{
			initconfig();
		}

		public static bool menucheck()
		{
			return Main.gameMenu;
		}

		//see if an item/monster exist with that name
		public static int doesItemexist(string name)
		{
			foreach(var item in Itemlist)
			{
				if(item.Name.ToLower() == name)
				{
					return item.ID;
				}
			}
			return -1;
		}

		public static int doesNPCexist(string name)
		{
			foreach (var item in NPClist)
			{
				if (item.Name.ToLower() == name)
				{
					return item.ID;
				}
			}
			return -1;
		}

		public void initconfig()
		{
			priceconfig.CheckifExist();
			//reading the config
			Itemlist = priceconfig.getItemConfig();
			NPClist = priceconfig.getNPCConfig();
			//remaking the lists to make sure IDs are still the up to date, just keeping prices. (IDs are "reshuffled" for Moditems everytime you change your modlist)
			Itemlist = priceconfig.HardRepopulateItems(Itemlist);
			NPClist = priceconfig.HardRepopulateNPCs(NPClist);
			//write the "up to date" lists back to the configfiles.
			priceconfig.OverwriteItemConfig(Itemlist);
			priceconfig.OverwriteNPCConfig(NPClist);
		}
	}
}