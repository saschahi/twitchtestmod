using IL.Terraria.IO;
using ProjectT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace twitchtestmod
{
    class TwitchInput : TwitchHandler
    {
        //this works just like modding for tModLoader normally

        public override void MessageHandler(Viewer viewer, string message, int bits)
        {
            //do whatever you want here

            //A Viewer is made out of

            string name = viewer.Name; //his name

            double coins = viewer.Coins; //which can be used later

            bool mod = viewer.mod; //see if he's a chat moderator

            bool vip = viewer.vip; //self-explaining

            bool subscriber = viewer.subscriber; //self-explaining

            DateTime time = viewer.last_seen; // it's formatted as DateTime.UTCNow

            //and the

            string chat = message; //message that was sent through the chat.

            //and also

            int Bits = bits; //includes the bits (if the message had some)

            //here starts commandhandler
            commandhandler(viewer, message);

        }

        //end of example

        //For a list of all users

        public static List<Viewer> locallist = new List<Viewer>();


        public override void onViewerListUpdate(List<Viewer> ListOfAllViewers)
        {
            //use this if you need a list of ALL viewers at all time. This updates everytime a viewer gets added or coins added/removed.

            //not only "online" viewers get sent. BUT ALL HISTORICAL VIEWERS ~~~ Yes I'll find a nicer/async/queued way once people show up with lists of 1000+ historical users.

            //ofcourse it also gets sent once at "PostAddRecipes" to start off.

            locallist = ListOfAllViewers;
        }

        public override void onCommunitySubscription(Viewer viewer)
        {
            //I'm not actually sure what this is yet. If you figure it out tell me.
        }

        public override void onBeingHosted(string Hoster, int AmountofViewers)
        {
            //BEWARE. this only gets the name of the hoster. NOT AN INSTANCE OF A VIEWER. 
            //A Viewer will be created once the hoster writes in chat like everyone else.

            //name says it all
        }

        public override void onConnected()
        {
            //gets called when the Bot Connects to Twitch
        }

        public override void onConnectionError()
        {
            //name says it all
        }

        public override void onDisconnected()
        {
            //Gets called when the Bot Disconnects from twitch
        }

        public override void onGiftedSubscription(Viewer viewer)
        {
            //name says it all
        }

        public override void onIncorrectLogin()
        {
            //gets called when the bot can't connect with the Twitch chat due to wrong Login credentials (botname + oauth code)
        }

        public override void onNewSubscriber(Viewer viewer, string tier)
        {
            //name says it all
        }


        public override void onReSubscriber(Viewer viewer, string tier)
        {
            //name says it all
        }

        public override void WhisperMessageHandler(Viewer viewer, string message)
        {
            //gets called when the bot gets whispered to
        }






        public void commandhandler(Viewer viewer, string message)
        {
            //here we'll make our commandchecks
            if (message.StartsWith("!buy "))
            {
                //if it's the !buy command, send it to forward to get processed
                BuyCommand(viewer, message);
            }
        }



        public void BuyCommand(Viewer viewer, string message)
        {
            if (!twitchtestmod.menucheck())
            {
                //just some code to process the message. people could write all sorts of dumb shit after !buy
                string v1 = null;
                string v2 = null;
                string v3 = null;
                string v4 = null;
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
                if(v4 == null)
                {
                    //and if the amount is null, we can assume only 1 should be bought (if someone does "!buy zombie" without an amount)
                    v4 = "1";
                }

                if (v4 != null && v2 != null)
                {
                    //look if an NPC with that name exist

                    int answer = twitchtestmod.doesNPCexist(v2);
                    if (answer != -1)
                    {
                        //if yes, send it to the commandhandler
                        try
                        {
                            Commands.BuyNPCCommand(viewer, answer, Convert.ToInt32(v4));
                        }
                        catch { }
                    }
                    else
                    {
                        //look if an item with that name exists
                        answer = twitchtestmod.doesItemexist(v2);
                        if (answer != -1)
                        {
                            //if yes, send it to the commandhandler
                            try
                            {
                                Commands.BuyItemCommand(viewer, answer, Convert.ToInt32(v4));
                            }
                            catch { }
                        }
                    }
                }


            }
        }
    }
}
