using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using NReco.ImageGenerator;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Movie_bot.Modules;
using Movie_bot.Core.GuildInfos;

namespace Movie_bot.Modules
{
    public class smallkick : ModuleBase<SocketCommandContext>
    {
        [Command("Channelkick")]
        [RequireBotPermission(GuildPermission.ManageChannels)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        [Alias("CK","smallkick")]
        public async Task Commands(SocketGuildUser user)
        {
            var target = Context.Guild;
            var getguild = GuildInfos.GetGuild(target);
            if(Context.Guild.CurrentUser.GuildPermissions.MoveMembers)
            {
                if (user.VoiceState.HasValue)
                {
                    IVoiceChannel Channel = await Context.Guild.CreateVoiceChannelAsync("Kick");
                    await user.ModifyAsync(USER_PROP =>
                    {
                        USER_PROP.ChannelId = Channel.Id;
                    });
                    await Channel.DeleteAsync();
                }
                else
                {
                    var ErrorEmbed = new EmbedBuilder();
                    ErrorEmbed.WithDescription($"{user.Username} needs to be in a voice channel");
                    await ReplyAsync("", false, ErrorEmbed);
                }
            }
        }
    }
}
