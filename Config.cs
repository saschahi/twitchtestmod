using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace twitchtestmod
{
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static Config Instance;

        [Label("Blacklist/Whitelist NPCs")]
        [Tooltip("If you want to disable specific NPCs, add them here.")]
        public List<NPCDefinition> BannedNPC { get; set; } = new List<NPCDefinition>();

        [Label("Whitelist Mode NPC")]
        [Tooltip("if true, the Banned NPC list becomes a Whitelist and only NPCs in that list can be bought.")]

        public bool whitelistmodeNPC { get; set; } = new bool();

        [Label("Blacklist/Whitelist Items")]
        [Tooltip("Put all Items you want to disable in here")]

        public List<ItemDefinition> BannedItems { get; set; } = new List<ItemDefinition>();

        [Label("Whitelist Mode Items")]
        [Tooltip("if true, the Banned Item list becomes a Whitelist and only Items in that list can be bought.")]

        public bool whitelistmodeItems { get; set; } = new bool();

        [Label("Disable Bosses (Very Recommended, lots of glitches.)")]
        [Tooltip("if true, Bosses can't be bought")]
        [DefaultValue(true)]

        public bool disablebosses { get; set; } = new bool();

        [Label("Disable Town-NPCs")]
        [Tooltip("if true, Town-NPCs can't be bought")]

        public bool disabletownies { get; set; } = new bool();

        [Label("Disable All NPCs")]
        [Tooltip("if true, NPCs can't be bought")]

        public bool disableNPC { get; set; } = new bool();

        [Label("Disable All Items")]
        [Tooltip("if true, Items can't be bought")]

        public bool disableItems { get; set; } = new bool();

        [Label("Send A Message ingame if a Viewer buys something")]
        [Tooltip("Self-Explanatory")]

        public bool ChatBuyAlert { get; set; } = new bool();

        [Label("Disable Buffs")]
        [Tooltip("if true, Buffs can't be bought")]

        public bool disableBuffs { get; set; } = new bool();

        public override void OnLoaded()
        {
            Commands.TConfig = ModContent.GetInstance<Config>();
        }
        public override void OnChanged()
        {
            Commands.TConfig = ModContent.GetInstance<Config>();
        }
    }

    public class commandconfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Purchaselist Command")]
        //[Tooltip("")]
        [DefaultValue("purchaselist")]
        public string purchaseliststring { get; set; }

        [Label("Purchaselist URL")]
        //[Tooltip("")]
        [DefaultValue("https://saschahi.github.io/TerrariaList/")]
        public string purchaselisturl { get; set; }

        [Label("Buy Command")]
        //[Tooltip("")]
        [DefaultValue("buy")]
        public string buystring { get; set; }


        public override void OnLoaded()
        {
            Commands.CConfig = ModContent.GetInstance<commandconfig>();
        }
        public override void OnChanged()
        {
            Commands.CConfig = ModContent.GetInstance<commandconfig>();
        }
    }

}
