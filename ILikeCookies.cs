using ProjectT;
using System;
using System.Collections.Generic;

namespace twitchtestmod
{
    class ILikeCookies : TwitchHandler
    {
        public override void MessageHandler(Viewer viewer, string message, int bits)
        {
            //do whatever you want here

            //A Viewer is made out of

            string name = viewer.Name; //his name

            double coins = viewer.Coins; //which can be used later

            bool mod = viewer.mod; //see if he's a chat moderator

            bool vip = viewer.vip;

            bool subscriber = viewer.subscriber;

            DateTime time = viewer.last_seen; // it's in DateTime.UTCNow

            //and the

            string chat = message; //message that was sent through the chat.

            //and also

            int Bits = bits; //includes the bits (if the message had some)

            //spawning x amount of random enemies per bit sounds fun lol
        }

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

        public override void onNewSubscriber(Viewer viewer)
        {
            //name says it all
        }

        public override void onReSubscriber(Viewer viewer)
        {
            //name says it all
        }

        public override void WhisperMessageHandler(Viewer viewer, string message)
        {
            //gets called when the bot gets whispered to
        }
    }
}
