using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitchtestmod
{
    public class TBuff
    {
        public TBuff()
        {

        }
        public TBuff(string name, double price, int id)
        {
            Name = name;
            Price = price;
            ID = id; ;
            Mod = "Manual";
        }

        public string Name;
        public double Price;
        public int ID;
        public string Mod;
    }
}
