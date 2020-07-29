using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Discord;
using Movie_bot.Core.GuildInfos;


namespace Movie_bot.Modules.Commands
{
    public class Ban : ModuleBase<SocketCommandContext>
    {
        [Command("SoftBan")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task SoftBan(SocketGuildUser user,[Remainder] string msg)
        {
            await user.SendMessageAsync($"you have been ban from {Context.Guild.Name} for {msg}");
            await Context.Guild.AddBanAsync(user, 7, msg);
            await Context.Guild.RemoveBanAsync(user);
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync($"{user.Mention} has been successfully banned for 1 second.");
        }
    }
}
