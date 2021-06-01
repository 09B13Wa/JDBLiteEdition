using System.Runtime.Remoting;
using Discord.Commands;

namespace Communication
{
    public class Channel
    {
        private long _discordId;
        private string _name;
        private Category _category;
        private Server _server;

        public Channel(Server server, long discordChannelId)
        {
            _server = server;
        }
    }
}