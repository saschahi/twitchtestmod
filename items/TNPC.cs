using System;

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
