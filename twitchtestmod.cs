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
		public static Mod herosmod;
		private static string heropermission = "ShopAllowed";
		private static string heropermissiondisplayname = "Allow Viewershop Usage";


		//theoretically not required
		public static twitchtestmod instance;

		public override void Load()
		{
			ProjectT = ModLoader.GetMod("ProjectT");
			herosmod = ModLoader.GetMod("HEROsMod");
			instance = this;
			SetupHerosMod();
		}

		public override void Unload()
		{
			ProjectT = null;
			Itemlist = null;
			NPClist = null;
			Bufflist = null;
			instance = null;
			herosmod = null;
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

		public void SetupHerosMod()
		{
			if (herosmod != null)
			{
				herosmod.Call(
					// Special string
					"AddPermission",
					// Permission Name
					heropermission,
					// Permission Display Name
					heropermissiondisplayname);
				/*
				if (!Main.dedServ)
				{
					herosmod.Call(
						// Special string
						"AddSimpleButton",
						// Name of Permission governing the availability of the button/tool
						heropermission,
						// Texture of the button. 38x38 is recommended for HERO's Mod. Also, a white outline on the icon similar to the other icons will look good.
						GetTexture("ShopButton"),
						// A method that will be called when the button is clicked
						(Action)ShopButtonPressed,
						// A method that will be called when the player's permissions have changed
						(Action<bool>)ShopPermissionChanged,
						// A method that will be called when the button is hovered, returning the Tooltip
						(Func<string>)ShopTooltip
					);
				}
				*/
			}
		}

		public bool GetPermission(int playernumber)
		{
			if(herosmod != null)
			{
				return herosmod.Call("HasPermission", playernumber, heropermission) is bool result && result;
			}
			return true;
		}
		/*
		public void ShopButtonPressed()
		{

		}

		public void ShopPermissionChanged(bool b)
		{

		}

		public string ShopTooltip()
		{
			return "This button doesn't have a function yet";
		}
		*/
	}
}