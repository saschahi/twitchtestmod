using System.Collections.Generic;

namespace twitchtestmod
{
    static public class BuffList
    {
        //because there's no (easy) way to get all buffs. If you find one tell me.
        public static List<TBuff> getNewBuffList()
        {
            List<TBuff> tocreate = new List<TBuff>();

            tocreate.Add(new TBuff("obsidianskin", 5, Terraria.ID.BuffID.ObsidianSkin));
            tocreate.Add(new TBuff("regeneration", 4, Terraria.ID.BuffID.Regeneration));
            tocreate.Add(new TBuff("swiftness", 4, Terraria.ID.BuffID.Swiftness));
            tocreate.Add(new TBuff("gills", 4, Terraria.ID.BuffID.Gills));
            tocreate.Add(new TBuff("ironskin", 1, Terraria.ID.BuffID.Ironskin));
            tocreate.Add(new TBuff("manaregeneration", 2, Terraria.ID.BuffID.ManaRegeneration));
            tocreate.Add(new TBuff("magicpower", 3, Terraria.ID.BuffID.MagicPower));
            tocreate.Add(new TBuff("featherfall", 2, Terraria.ID.BuffID.Featherfall));
            tocreate.Add(new TBuff("spelunker", 2, Terraria.ID.BuffID.Spelunker));
            tocreate.Add(new TBuff("invisibility", 5, Terraria.ID.BuffID.Invisibility));
            tocreate.Add(new TBuff("shine", 3, Terraria.ID.BuffID.Shine));
            tocreate.Add(new TBuff("nightowl", 2, Terraria.ID.BuffID.NightOwl));
            tocreate.Add(new TBuff("battle", 7, Terraria.ID.BuffID.Battle));
            tocreate.Add(new TBuff("thorns", 1, Terraria.ID.BuffID.Thorns));
            tocreate.Add(new TBuff("waterwalking", 3, Terraria.ID.BuffID.WaterWalking));
            tocreate.Add(new TBuff("archery", 3, Terraria.ID.BuffID.Archery));
            tocreate.Add(new TBuff("hunter", 3, Terraria.ID.BuffID.Hunter));
            tocreate.Add(new TBuff("gravitation", 12, Terraria.ID.BuffID.Gravitation));
            tocreate.Add(new TBuff("poisoned", 12, Terraria.ID.BuffID.Poisoned)); //2dps
            tocreate.Add(new TBuff("potionsickness", 15, Terraria.ID.BuffID.PotionSickness));
            tocreate.Add(new TBuff("darkness", 15, Terraria.ID.BuffID.Darkness));
            tocreate.Add(new TBuff("cursed", 40, Terraria.ID.BuffID.Cursed));
            tocreate.Add(new TBuff("onfire", 25, Terraria.ID.BuffID.OnFire)); //4dps + no regen
            tocreate.Add(new TBuff("tipsy", 10, Terraria.ID.BuffID.Tipsy));
            tocreate.Add(new TBuff("wellfed", 1, Terraria.ID.BuffID.WellFed));
            tocreate.Add(new TBuff("Clairvoyance", 1, Terraria.ID.BuffID.Clairvoyance));
            tocreate.Add(new TBuff("bleeding", 8, Terraria.ID.BuffID.Bleeding));
            tocreate.Add(new TBuff("confused", 50, Terraria.ID.BuffID.Confused));
            tocreate.Add(new TBuff("slow", 15, Terraria.ID.BuffID.Slow));
            tocreate.Add(new TBuff("weak", 10, Terraria.ID.BuffID.Weak));
            tocreate.Add(new TBuff("silenced", 35, Terraria.ID.BuffID.Silenced));
            tocreate.Add(new TBuff("brokenarmor", 25, Terraria.ID.BuffID.BrokenArmor));
            tocreate.Add(new TBuff("cursedinferno", 36, Terraria.ID.BuffID.CursedInferno)); //6dps
            tocreate.Add(new TBuff("frostburn", 38, Terraria.ID.BuffID.Frostburn)); //6dps + no regen
            tocreate.Add(new TBuff("chilled", 15, Terraria.ID.BuffID.Chilled));
            tocreate.Add(new TBuff("Frozen", 100, Terraria.ID.BuffID.Frozen));
            tocreate.Add(new TBuff("honey", 2, Terraria.ID.BuffID.Honey));
            tocreate.Add(new TBuff("panic", 10, Terraria.ID.BuffID.Panic));
            tocreate.Add(new TBuff("burning", 500, Terraria.ID.BuffID.Burning)); //50dps may actually not work
            tocreate.Add(new TBuff("suffocation", 200, Terraria.ID.BuffID.Suffocation)); //20dps may actually not work
            tocreate.Add(new TBuff("ichor", 15, Terraria.ID.BuffID.Ichor));
            tocreate.Add(new TBuff("venom", 38, Terraria.ID.BuffID.ObsidianSkin)); //6dps + no regen
            tocreate.Add(new TBuff("weaponimbuevenom", 2, Terraria.ID.BuffID.WeaponImbueVenom));
            tocreate.Add(new TBuff("weaponimbuecursedflame", 2, Terraria.ID.BuffID.WeaponImbueCursedFlames));
            tocreate.Add(new TBuff("weaponimbuefire", 1, Terraria.ID.BuffID.WeaponImbueFire));
            tocreate.Add(new TBuff("weaponimbuegold", 1, Terraria.ID.BuffID.WeaponImbueGold));
            tocreate.Add(new TBuff("weaponimbueichor", 3, Terraria.ID.BuffID.WeaponImbueIchor));
            tocreate.Add(new TBuff("weaponimbuenanites", 4, Terraria.ID.BuffID.WeaponImbueNanites));
            tocreate.Add(new TBuff("weaponimbueconfetti", 1, Terraria.ID.BuffID.WeaponImbueConfetti));
            tocreate.Add(new TBuff("weaponimbuepoison", 1, Terraria.ID.BuffID.WeaponImbuePoison));
            tocreate.Add(new TBuff("blackout", 50, Terraria.ID.BuffID.Blackout));
            tocreate.Add(new TBuff("chaosstate", 20, Terraria.ID.BuffID.ChaosState)); //for the luls
            tocreate.Add(new TBuff("ammobox", 1, Terraria.ID.BuffID.AmmoBox));
            tocreate.Add(new TBuff("manasickness", 4, Terraria.ID.BuffID.ManaSickness));
            tocreate.Add(new TBuff("wet", 1, Terraria.ID.BuffID.Wet));
            tocreate.Add(new TBuff("miningbuff", 2, Terraria.ID.BuffID.Mining));
            tocreate.Add(new TBuff("heartreach", 1, Terraria.ID.BuffID.Heartreach));
            tocreate.Add(new TBuff("calm", 2, Terraria.ID.BuffID.Calm));
            tocreate.Add(new TBuff("titan", 2, Terraria.ID.BuffID.Titan));
            tocreate.Add(new TBuff("flipper", 4, Terraria.ID.BuffID.Flipper));
            tocreate.Add(new TBuff("summoningbuff", 2, Terraria.ID.BuffID.Summoning));
            tocreate.Add(new TBuff("dangersense", 4, Terraria.ID.BuffID.Dangersense));
            tocreate.Add(new TBuff("ammoreservation", 2, Terraria.ID.BuffID.AmmoReservation));
            tocreate.Add(new TBuff("lifeforce", 1, Terraria.ID.BuffID.Lifeforce));
            tocreate.Add(new TBuff("endurance", 2, Terraria.ID.BuffID.Endurance));
            tocreate.Add(new TBuff("rage", 5, Terraria.ID.BuffID.Rage));
            tocreate.Add(new TBuff("inferno", 6, Terraria.ID.BuffID.Inferno));
            tocreate.Add(new TBuff("wrath", 5, Terraria.ID.BuffID.Wrath));
            tocreate.Add(new TBuff("lovestruck", 1, Terraria.ID.BuffID.Lovestruck));
            tocreate.Add(new TBuff("stinky", 1, Terraria.ID.BuffID.Stinky));
            tocreate.Add(new TBuff("fishingbuff", 1, Terraria.ID.BuffID.Fishing));
            tocreate.Add(new TBuff("sonar", 2, Terraria.ID.BuffID.Sonar));
            tocreate.Add(new TBuff("crate", 1, Terraria.ID.BuffID.Crate));
            tocreate.Add(new TBuff("warmth", 1, Terraria.ID.BuffID.Warmth));
            tocreate.Add(new TBuff("electrified", 50, Terraria.ID.BuffID.Electrified)); // 4/16dps may not work
            tocreate.Add(new TBuff("moonbite", 15, Terraria.ID.BuffID.MoonLeech)); //may not work
            tocreate.Add(new TBuff("webbed", 90, Terraria.ID.BuffID.Webbed));
            tocreate.Add(new TBuff("bewitched", 1, Terraria.ID.BuffID.Bewitched));
            tocreate.Add(new TBuff("shadowflame", 90, Terraria.ID.BuffID.ShadowFlame));//15dps + no regen
            tocreate.Add(new TBuff("stoned", 100, Terraria.ID.BuffID.Stoned));
            tocreate.Add(new TBuff("sharpened", 1, Terraria.ID.BuffID.Sharpened));
            tocreate.Add(new TBuff("dazed", 15, Terraria.ID.BuffID.Dazed));
            tocreate.Add(new TBuff("obstructed", 80, Terraria.ID.BuffID.Obstructed));
            tocreate.Add(new TBuff("distorted", 30, 164)); //can't find it in BuffID.... bad sign..
            tocreate.Add(new TBuff("dryadsblessing", 1, Terraria.ID.BuffID.DryadsWard));
            tocreate.Add(new TBuff("penetrated", 18, 169)); //3dps
            tocreate.Add(new TBuff("dryadsbane", 50, Terraria.ID.BuffID.DryadsWardDebuff)); //up to 16dps
            tocreate.Add(new TBuff("witheredarmor", 25, Terraria.ID.BuffID.WitheredArmor));
            tocreate.Add(new TBuff("witheredweapon", 40, Terraria.ID.BuffID.WitheredWeapon));
            tocreate.Add(new TBuff("oozed", 20, Terraria.ID.BuffID.OgreSpit));
            tocreate.Add(new TBuff("strikingmoment", 3, 198));
            tocreate.Add(new TBuff("creativeshock", 20, 199)); //might not work
            //teststuff
            tocreate.Add(new TBuff("rapidhealing", 10, Terraria.ID.BuffID.RapidHealing)); //armor-buffs seem to work...
            //tocreate.Add(new TBuff("pygmies", 10, Terraria.ID.BuffID.Pygmies)); summons don't work
            //tocreate.Add(new TBuff("babyslime", 10, Terraria.ID.BuffID.BabySlime)); pets doN't work
            tocreate.Add(new TBuff("drill", 20, Terraria.ID.BuffID.DrillMount)); // mounts seem to work

            return tocreate;
        }

        
    }
}
