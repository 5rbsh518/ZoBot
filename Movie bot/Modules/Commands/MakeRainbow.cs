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
using System.Threading;

namespace Movie_bot.Modules.Commands
{
    public class MakeRanibow : ModuleBase<SocketCommandContext>
    {
        [Command("RainbowRole")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task MakeRainbowRole(SocketRole role)
        {
            Random random = new Random();
            int waittime = 100;
            while(true)
                {
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(255,0,0);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(255,165,0);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(255, 255, 0);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(128, 255, 0);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(0, 255, 0);
                    x.Hoist = true;
                });
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(135, 206, 235);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
                Thread.Sleep(waittime);
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(0, 0, 255);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(75, 0, 130);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(238, 130, 238);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
            }
        }
        [Command("OthmanRainbow")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task OthmanRianbow(SocketRole role)
        {
            Random random = new Random();
            int waittime = 100;
            while (true)
            {
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color( 1, 1, 1);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
                await role.ModifyAsync(x =>
                {
                    x.Color = new Color(255, 255, 255);
                    x.Hoist = true;
                });
                Thread.Sleep(waittime);
            }
        }
    }
}