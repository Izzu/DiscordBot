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

            //command instigator
            discord.UsingCommands(x =>
            {
                x.PrefixChar = '/';
                x.HelpMode = HelpMode.Public;
            });

            //command service variable
            var commands = discord.GetService<CommandService>();

            //hello command
            commands.CreateCommand("hello")
                .Alias("hi")
                .Description("Says hello back.")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hi");
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjQ3NDkwNTc0MTkyNDc2MTYx.CwqEfw.GySquE25grhI_WXXbx1mXD5_RHI", TokenType.Bot);
            });
        }


        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
