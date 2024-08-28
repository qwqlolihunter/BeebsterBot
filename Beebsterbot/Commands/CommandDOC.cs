using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beebsterbot.Commands
{
    public class CommandDOC : BaseCommandModule
    {
        [Command("test")]
        public async Task TestCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Testing sending message");
        }
    }
}
