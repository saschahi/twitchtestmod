using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace twitchtestmod
{
    public class TNPC
    {
        public string Name;
        public double Price;
        public int ID;
        public string Mod;

        public TNPC()
        {

        }

        public TNPC(string name, double price, int id)
        {
            Name = name;
            Price = price;
            ID = id;
            Mod = "Vanilla";
        }
    }
}
