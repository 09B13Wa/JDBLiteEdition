using System.Collections.Generic;
using Discord.WebSocket;
namespace Communication
{
    public class Server
    {
        private HashSet<Category> _categories;
        private SocketGuild _socketGuild;

        public Server(Client client, long serverId)
        {
            
            _categories = new HashSet<Category>();
        }
    }
}