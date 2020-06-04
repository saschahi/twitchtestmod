using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace twitchtestmod
{
    public static class priceconfig
    {
        private static string NPCListPath = Path.Combine(Main.SavePath, "TProject", "Shop", "NPCList.json");
        private static string ItemListPath = Path.Combine(Main.SavePath, "TProject", "Shop",  "ItemList.json");
        private static string BuffListPath = Path.Combine(Main.SavePath, "TProject", "Shop", "BuffList.json");
        private static string Generalpath = Path.Combine(Main.SavePath, "TProject", "Shop");
        public static int damagepricemultiplier = 10;

        public static void CheckifExist()
        {
            Directory.CreateDirectory(Generalpath);
            if(!File.Exists(NPCListPath))
            {
                CreateNPCConfigfile();
            }
            if(!File.Exists(ItemListPath))
            {
                CreateItemConfigfile();
            }
            if(!File.Exists(BuffListPath))
            {
                CreateBuffConfigfile();
            }
        }

        public static void CreateNPCConfigfile()
        {
            TNPCjsonhelper mem = new TNPCjsonhelper();
            mem.List = generateNPCList();
            string json = JsonConvert.SerializeObject(mem, Formatting.Indented);
            File.WriteAllText(NPCListPath, json.ToString());
        }

        public static void CreateItemConfigfile()
        {
            TItemjsonhelper mem = new TItemjsonhelper();
            mem.List = generateItemList();
            string json = JsonConvert.SerializeObject(mem, Formatting.Indented);
            File.WriteAllText(ItemListPath, json.ToString());
        }

        public static void CreateBuffConfigfile()
        {
            TBuffjsonhelper mem = new TBuffjsonhelper();
            mem.List = BuffList.getNewBuffList();
            string json = JsonConvert.SerializeObject(mem, Formatting.Indented);
            File.WriteAllText(BuffListPath, json.ToString());
        }

        public static void OverwriteNPCConfig(List<TNPC> NPCList)
        {
            TNPCjsonhelper mem = new TNPCjsonhelper();
            mem.List = NPCList;
            string json = JsonConvert.SerializeObject(mem, Formatting.Indented);
            File.WriteAllText(NPCListPath, json.ToString());
        }
        public static void OverwriteItemConfig(List<TItem> Itemlist)
        {
            TItemjsonhelper mem = new TItemjsonhelper();
            mem.List = Itemlist;
            string json = JsonConvert.SerializeObject(mem, Formatting.Indented);
            File.WriteAllText(ItemListPath, json.ToString());
        }
        public static void OverwriteBuffConfig(List<TBuff> Bufflist)
        {
            TBuffjsonhelper mem = new TBuffjsonhelper();
            mem.List = Bufflist;
            string json = JsonConvert.SerializeObject(mem, Formatting.Indented);
            File.WriteAllText(BuffListPath, json.ToString());
        }

        public static List<TNPC> getNPCConfig()
        {
            List<TNPC> mem = new List<TNPC>();
            JObject o1 = JObject.Parse(File.ReadAllText(NPCListPath));
            TNPCjsonhelper read = o1.ToObject<TNPCjsonhelper>();
            mem = read.List;
            return mem;
        }

        public static List<TItem> getItemConfig()
        {
            List<TItem> mem = new List<TItem>();
            JObject o1 = JObject.Parse(File.ReadAllText(ItemListPath));
            TItemjsonhelper read = o1.ToObject<TItemjsonhelper>();
            mem = read.List;
            return mem;
        }

        public static List<TBuff> getBuffConfig()
        {
            List<TBuff> mem = new List<TBuff>();
            JObject o1 = JObject.Parse(File.ReadAllText(BuffListPath));
            TBuffjsonhelper read = o1.ToObject<TBuffjsonhelper>();
            mem = read.List;
            return mem;
        }

        public static List<TItem> RepopulateItems(List<TItem> old)
        {
            //Adds all missing Items, but doesn't remove unused ones.
            List<TItem> tocreate= new List<TItem>();

            for (int i = 0; i < NPCLoader.NPCCount; i++)
            {
                try
                {
                    Item Item = new Item();
                    Item.SetDefaults(i);
                    string normalizedname = new string(Item.Name.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());
                    bool found = false;
                    foreach(var item in old)
                    {
                        if(item.Name == normalizedname && item.ID == Item.type)
                        {
                            found = true;
                            tocreate.Add(item);
                            break;
                        }
                    }

                    if (!found)
                    {
                        TItem mem = new TItem();
                        mem.Name = normalizedname;
                        mem.ID = Item.type;
                        mem.Price = Item.value;
                        if (mem.Price <= 0)
                        {
                            mem.Price = 10;
                        }
                        tocreate.Add(mem);
                    }
                }
                catch { }
            }

            return tocreate;
        }

        public static List<TNPC> RepopulateNPCs(List<TNPC> old)
        {
            //Adds all missing NPCs, but doesn't remove unused ones.
            List<TNPC> tocreate = new List<TNPC>();

            for (int i = 0; i < NPCLoader.NPCCount; i++)
            {
                try
                {
                    NPC npc = new NPC();
                    npc.SetDefaults(i);
                    string normalizedname = new string(npc.FullName.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());
                    bool found = false;
                    foreach (var item in old)
                    {
                        if (item.Name == normalizedname && item.ID == npc.type)
                        {
                            found = true;
                            tocreate.Add(item);
                            break;
                        }
                    }
                    if (!found)
                    {
                        TNPC mem = new TNPC();
                        mem.Name = normalizedname;
                        mem.ID = npc.type;
                        mem.Price = npc.lifeMax + (npc.damage * damagepricemultiplier);
                        if (mem.Price <= 0)
                        {
                            mem.Price = 99999;
                        }
                        tocreate.Add(mem);
                    }
                }
                catch { }
            }

            return tocreate;
        }

        public static List<TItem> HardRepopulateItems(List<TItem> old)
        {
            List<TItem> tofill = new List<TItem>();
            List<TItem> mem = generateItemList();
            foreach(var newitem in mem)
            {
                foreach(var olditem in old)
                {
                    if(newitem.Name == olditem.Name && newitem.Mod == olditem.Mod)
                    {
                        newitem.Price = olditem.Price;
                    }
                }
                tofill.Add(newitem);
            }

            foreach(var olditem in old)
            {
                bool found = false;
                foreach(var newitem in mem)
                {
                    if (olditem.Name == newitem.Name)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    tofill.Add(olditem);
                }
            }
            return tofill;
        }
        public static List<TNPC> HardRepopulateNPCs(List<TNPC> old)
        {
            List<TNPC> tofill = new List<TNPC>();
            List<TNPC> mem = generateNPCList();
            foreach(var newitem in mem)
            {
                foreach(var olditem in old)
                {
                    if(newitem.Name == olditem.Name && newitem.Mod == olditem.Mod)
                    {
                        newitem.Price = olditem.Price;
                        break;
                    }
                }
                tofill.Add(newitem);
            }

            foreach(var olditem in old)
            {
                bool found = false;
                foreach(var newitem in mem)
                {
                    if (olditem.Name == newitem.Name)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    tofill.Add(olditem);
                }
            }

            return tofill;
        }

        public static List<TNPC> generateNPCList()
        {
            List<TNPC> tocreate = new List<TNPC>();
            List<NPCDefinition> broken = BrokenNPCs.getBrokenNPCs();
            for (int i = 0; i < NPCLoader.NPCCount; i++)
            {

                NPC npc = new NPC();
                npc.SetDefaults(i);
                TNPC mem = new TNPC();
                mem.Name = new string(npc.FullName.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());
                mem.ID = npc.type;
                mem.Price = npc.lifeMax + (npc.defense * 2) + (npc.damage * damagepricemultiplier);
                if (npc.modNPC != null)
                {
                    mem.Mod = npc.modNPC.mod.ToString();
                }
                else
                {
                    mem.Mod = "Vanilla";
                }
                if (mem.Price <= 0)
                {
                    mem.Price = 99999;
                }
                NPCDefinition totest = new NPCDefinition(npc.type);
                if(!broken.Contains(totest))
                {
                    tocreate.Add(mem);
                }
            }
            return tocreate;
        }

        public static List<TItem> generateItemList()
        {
            List<TItem> tocreate = new List<TItem>();

            for (int i = 0; i < ItemLoader.ItemCount; i++)
            {

                Item Item = new Item();
                Item.SetDefaults(i);
                TItem mem = new TItem();
                mem.Name = new string(Item.Name.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());
                mem.ID = Item.type;
                mem.Price = Item.value;
                if (Item.modItem != null)
                {
                    mem.Mod = Item.modItem.mod.ToString();
                }
                else
                {
                    mem.Mod = "Vanilla";
                }
                if (mem.Price <= 0)
                {
                    mem.Price = 10;
                }
                tocreate.Add(mem);
            }
            return tocreate;
        }
        
        public static List<TBuff> generateBuffList()
        {
            return BuffList.getNewBuffList();
            //Todo - find way to get all buffs
            //or not... I'd have to go through and manually assign prices and remove summons anyway.
        }
    }
}
