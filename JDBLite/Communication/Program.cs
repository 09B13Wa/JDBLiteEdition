using System;
using System.Threading.Tasks;

namespace Communication
{
    internal class Program
    {
        public static void Main(string[] args) => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string[] args)
        {
            int numberOfArgs = args.Length;
            if (numberOfArgs >= 2)
            {
                string tokenArg = args[1];
                long token = long.Parse(tokenArg);
                BotClient botClient;
                if (numberOfArgs >= 3)
                    botClient = new BotClient(token, args[2]);
                else
                    botClient = new BotClient(token);
            }
            else
                throw new ArgumentException($"Expected at least 1 argument but got {numberOfArgs}");
        }
    }
}