using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Net;
using Newtonsoft.Json;
using Movie_bot.Modules;
using Discord.Rest;

namespace Movie_bot.Modules.Commands
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("Admins")]
        public async Task OfflineAndOnlineAdmins()
        {
            string OnlineAdmins = "";
            string OfflineAdmins = "";
            int OnlineAdminsNumber = 0;
            int OfflineAdminsNumber = 0;
            Random random = new Random();
            var embed = new EmbedBuilder();

            foreach (var user in Context.Guild.Users)
            {
                if (user.GuildPermissions.Administrator)
                {
                    if (user.Status.ToString() != "Offline" && !user.IsBot)
                    {
                        OnlineAdminsNumber += 1;
                        OnlineAdmins = OnlineAdmins + $"{user.Mention} ";
                    }
                    if (user.Status.ToString() == "Offline" && !user.IsBot)
                    {
                        OfflineAdminsNumber += 1;
                        OfflineAdmins = OfflineAdmins + $"{user.Mention} ";
                    }
                }
            }
            embed.WithTitle("Online Admins");
            embed.WithDescription($"{OnlineAdmins}");
            embed.AddInlineField("OfflineAdmins", OfflineAdmins);
            embed.AddInlineField("Online admins number", OnlineAdminsNumber);
            embed.AddInlineField("Offline admins number", OfflineAdminsNumber);
            embed.WithColor(random.Next(0,256), random.Next(0, 256), random.Next(0, 256));

            await Context.Channel.SendMessageAsync("", false, embed);
        }
        [Command("OnlineAdmins")]
        public async Task OnlineAdmins()
        {
            string OnlineAdmins = "";
            int OnlineAdminsNumber = 0;
            Random random = new Random();
            var embed = new EmbedBuilder();

            foreach (var user in Context.Guild.Users)
            {
                if (user.GuildPermissions.Administrator)
                {
                    if (user.Status.ToString() != "Offline" && !user.IsBot)
                    {
                        OnlineAdminsNumber += 1;
                        OnlineAdmins = OnlineAdmins + $"{user.Mention} ";
                    }
                }
            }
            embed.WithTitle("Online Admins");
            embed.WithDescription($"{OnlineAdmins}");
            embed.AddInlineField("Online admins number", OnlineAdminsNumber);
            embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

            await Context.Channel.SendMessageAsync("", false, embed);
        }
        [Command("OfflineAdmins")]
        public async Task OfflineAdmins()
        {
            string OfflineAdmins = "";
            int OfflineAdminsNumber = 0;
            Random random = new Random();
            var embed = new EmbedBuilder();

            foreach (var user in Context.Guild.Users)
            {
                if (user.GuildPermissions.Administrator)
                {
                    if (user.Status.ToString() == "Offline" && !user.IsBot)
                    {
                        OfflineAdminsNumber += 1;
                        OfflineAdmins = OfflineAdmins + $"{user.Mention} ";
                    }
                }
            }
            embed.AddInlineField("OfflineAdmins", OfflineAdmins);
            embed.AddInlineField("Offline admins number", OfflineAdminsNumber);
            embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
