using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscordBot
{
    class aBot
    {
        DiscordClient discord;

        public aBot()
        {
            discord = new DiscordClient(x =>
                {
                    x.LogLevel = LogSeverity.Info;
                    x.LogHandler = Log;
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjQ3NDkwNTc0MTkyNDc2MTYx.CwqEfw.GySquE25grhI_WXXbx1mXD5_RHI", TokenType.Bot);
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.HelpMode = HelpMode.Public;
                x.AllowMentionPrefix = true;
            });

            //var commands = discord.GetService<CommandService>();

            discord.GetService<CommandService>().CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hi");
                });
        }


        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
