using IL.Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace twitchtestmod
{
    static public class BrokenNPCs
    {
        public static List<NPCDefinition> getBrokenNPCs()
        {
            List<NPCDefinition> mem = new List<NPCDefinition>();

            //golem
            mem.Add(new NPCDefinition(246));
            mem.Add(new NPCDefinition(247));
            mem.Add(new NPCDefinition(248));
            mem.Add(new NPCDefinition(249));
            //eater of worlds 13
            mem.Add(new NPCDefinition(14));
            mem.Add(new NPCDefinition(15));
            //bone serpent 39
            mem.Add(new NPCDefinition(40));
            mem.Add(new NPCDefinition(41));
            //devourer 7
            mem.Add(new NPCDefinition(8));
            mem.Add(new NPCDefinition(9));
            //giant worm 10
            mem.Add(new NPCDefinition(11));
            mem.Add(new NPCDefinition(12));
            //digger 95
            mem.Add(new NPCDefinition(96));
            mem.Add(new NPCDefinition(97));
            //world feeder 98
            mem.Add(new NPCDefinition(99));
            mem.Add(new NPCDefinition(100));
            //leech 117
            mem.Add(new NPCDefinition(118));
            mem.Add(new NPCDefinition(119));
            //wyvern 87
            mem.Add(new NPCDefinition(88));
            mem.Add(new NPCDefinition(89));
            mem.Add(new NPCDefinition(90));
            mem.Add(new NPCDefinition(91));
            mem.Add(new NPCDefinition(92));
            //skeletron 35
            mem.Add(new NPCDefinition(36));
            //prime
            mem.Add(new NPCDefinition(128));
            mem.Add(new NPCDefinition(129));
            mem.Add(new NPCDefinition(130));
            mem.Add(new NPCDefinition(131));
            //plantera
            mem.Add(new NPCDefinition(263));
            mem.Add(new NPCDefinition(264));
            //destroyer
            mem.Add(new NPCDefinition(135));
            mem.Add(new NPCDefinition(136));
            //pumpking
            mem.Add(new NPCDefinition(328));
            //WoF
            mem.Add(new NPCDefinition(113));
            mem.Add(new NPCDefinition(114));

			foreach(var item in Intlist)
			{
				mem.Add(new NPCDefinition(item));
			}


            return mem;
        }

		public static int[] Intlist = new int[]
			{
			0, //broken
			//68, // DUNGEONGUARDIAN MAKE FUN STUFF HAPPEN
			76, // broken
			146, //broken
			165, //doppelt
			171, //doppelt
			187, //zombies
			188, //zombies
			189, //Zombies
			191, //demoneye
			192,
			193,
			194, //demoneye
			195, //lostgirl...maybe remove?
			199, //doppelt
			200, //noch ein zombie
			202, //doppelt
			203, //dreifach
			211, //doppelt
			232, //hornets
			233,
			234,
			235, //hornets
			237, //doppelt
			240, //doppelt
			255, //doppelt
			270, //bones
			271,
			272,
			274,
			275,
			276,
			278,
			279,
			280, //bones
			282, //doppelt
			284, //doppelt
			286, //doppelt
			295, //doppelt
			296, //dreifach
			306, //scary bois
			307,
			308,
			309,
			310,
			311,
			312,
			313,
			314, //scary bois
			317, //wtf
			318, //mehr demoneyes
			320,
			321,
			322,
			323,
			324, //viel mehr normale mobs
			331,
			332,
			334,
			335,
			336,
			339,
			340,
			349,
			363,
			364,
			365,
			367,
			373,
			375,
			397, //moonlord hand
			398, //moonlord core
			403, //broken
			404, //broken
			406, //doppelt
			408, //broken
			413,
			414, //crawlyboi
			430, //mehr zombies...
			431, //zombie eskimo
			432,
			433,
			434,
			435,
			436, //soviele zombies
			440, //cultist doppelt...?
			449,
			450,
			451,
			452,
			455, //phantasmdragon
			456,
			457,
			458,
			459,
			488, //dummy
			497, //double
			499, //double
			500,
			501,
			502,
			503,
			504,
			505,
			506, //salamandar bis hier
			523, //ancientdoom??????
			531, //sandpoacher
			547, //???
			548, //crystall
			549, //portal
			556,
			557,
			559,
			560,
			562,
			563,
			565,
			567,
			569,
			572,
			573,
			575,
			577
			};
    }
}
