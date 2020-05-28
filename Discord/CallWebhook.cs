using System.Collections.Specialized;
using System.Net;

namespace twitchtestmod.Discord
{
    public static class CallWebhook
    {
        private static WebClient dWebClient;
        private static NameValueCollection discordValues = new NameValueCollection();
        public static string WebHook { get; set; }
        public static string UserName { get; set; }
        public static string ProfilePicture { get; set; }

        public static void Initialize(string webhook, string username, string profilepicture)
        {
            WebHook = webhook;
            UserName = username;
            ProfilePicture = profilepicture;
            dWebClient = new WebClient();
        }

        public static void SendMessage(string msgSend)
        {
            discordValues.Add("username", UserName);
            discordValues.Add("avatar_url", ProfilePicture);
            discordValues.Add("content", msgSend);
            dWebClient.UploadValues(WebHook, discordValues);
        }

        public static void Dispose()
        {
            dWebClient.Dispose();
        }
    }
}
