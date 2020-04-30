using ProjectT;
using System;
using Terraria.ModLoader;

namespace twitchtestmod
{
	public class twitchtestmod : Mod
	{
		//required
		ILikeCookies test = new ILikeCookies();
		public static Mod ProjectT;
		//theoretically not required
		public static twitchtestmod instance;

		public override void Load()
		{
			ProjectT = ModLoader.GetMod("ProjectT");
		}

		//how to send a message in Chat:
		static public void sendmessage(string message)
		{
			if (ProjectT != null)
			{
				//requires the operator "SendMessage" and a message
				ProjectT.Call("SendMessage", message);
			}
		}

		//send a whisper to a specific person
		static public void sendwhisper(string name, string message)
		{
			if (ProjectT != null)
			{
				//requires the operator "SendWhisper", a receiver and a message
				ProjectT.Call("SendWhisper", name, message);
			}
		}

		//The "Viewers" I require for adding and removing coins don't have to be 100% accurate. Only the Username and UserID are required. the rest can just be null.

		static public bool removecoins(Viewer viewer, double CoinsToRemove)
		{
			if (ProjectT != null)
			{
				//you cannot send a double. I convert it back to a double on my end. I have no idea why it is like that either.
				string req = Convert.ToString(CoinsToRemove);

				try
				{
					//requires the operator "RemoveCoins", a receiver the amount
					bool answer = ProjectT.Call("RemoveCoins", viewer, req) is bool result && result;
					return answer;
				}
				catch
				{
					return false;
				}
				//Note: checking if the viewer exists, and if he has enough coins is done on my part. you don't have to implement that
				//If the user doesn't exist or doesn't have enough coins I return a false
				//If the user exists, has enough coins and the coins were removed successfully, I return true
			}
			return false;
		}

		static public void addcoins(Viewer viewer, double CoinsToAdd)
		{
			if (ProjectT != null)
			{
				//you cannot send a double. I convert it back to a double on my end.
				string req = Convert.ToString(CoinsToAdd);

				//requires the operator "AddCoins", a receiver and amount
				ProjectT.Call("AddCoins", viewer, req);

				//I check on my side if the user exists. you don't have to. But you won't get a return here.
			}
		}
	}
}