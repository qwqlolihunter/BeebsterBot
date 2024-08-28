using Beebsterbot.Commands;
using Beebsterbot.Config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;

//Token + ID + Twitch API
namespace Beebsterbot
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }
        static async Task Main(string[] args)
        {
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;

            var commandConfigs = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = false,
                EnableDefaultHelp = false
            };

            Commands = Client.UseCommandsNext(commandConfigs);

            Commands.RegisterCommands<CommandDOC>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}