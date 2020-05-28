using ProjectT;
using System;
using System.Linq;

namespace twitchtestmod
{
    class TwitchInput : TwitchHandler
    {
        //this works just like modding for tModLoader normally

        public override void MessageHandler(Viewer viewer, string message, int bits)
        {
            commandhandler(viewer, message);

        }

        public static string buyCommand => Commands.CConfig.buystring;
        public static string Purchaselistcommand => Commands.CConfig.purchaseliststring;
        public static string Purchaselisturl => Commands.CConfig.purchaselisturl;

        public void commandhandler(Viewer viewer, string message)
        {
            //here we'll make our commandchecks
            if (message.StartsWith("!" + buyCommand))
            {
                //if it's the !buy command, send it to forward to get processed
                BuyCommand(viewer, message);
            }
            else if (message.StartsWith("!" + Purchaselistcommand))
            {
                PurchaselistCommand();
            }
        }

        public void PurchaselistCommand()
        {
            Calls.sendmessage("Here's the Shop-List: " + Purchaselisturl);
        }

        public void BuyCommand(Viewer viewer, string message)
        {
            if (!twitchtestmod.menucheck())
            {
                //just some code to process the message. people could write all sorts of dumb shit after !buy
                string v1 = null;
                string v2 = null;
                string v3 = null;
                string v4 = "1";
                if (message.Length > 9)
                {
                    v1 = message.Remove(0, 5);
                    v2 = new string(v1.TakeWhile(char.IsLetterOrDigit).ToArray());
                    if (v2.Length + 5 < message.Length)
                    {
                        string test = v1.Remove(0, v2.Length + 1);
                        if (test != " ")
                        {
                            v3 = v1.Remove(0, v2.Length + 1);
                            v4 = new string(v3.TakeWhile(char.IsDigit).ToArray());
                        }
                    }
                }

                //now v2 should be the name of the item/npc, and v4 should be the amount.

                if (v4 != null && v2 != null)
                {
                    //look if an NPC with that name exist
                    if (twitchtestmod.DoesBuffexist(v2, out TBuff Buff))
                    {
                        //if yes, send it to the commandhandler
                        try
                        {
                            Commands.BuyPotionEffectCommand(viewer, Buff, Convert.ToInt32(v4));
                        }
                        catch { }
                    }
                    else if (twitchtestmod.DoesNPCexist(v2, out int ID2))
                    {
                        //if yes, send it to the commandhandler
                        try
                        {
                            Commands.BuyNPCCommand(viewer, ID2, Convert.ToInt32(v4));
                        }
                        catch { }
                    }
                    else if (twitchtestmod.DoesItemexist(v2, out int ID3))
                    {
                        //if yes, send it to the commandhandler
                        try
                        {
                            Commands.BuyItemCommand(viewer, ID3, Convert.ToInt32(v4));
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
