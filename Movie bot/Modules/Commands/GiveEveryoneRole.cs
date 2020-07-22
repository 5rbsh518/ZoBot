using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Movie_bot.Modules.Commands
{

    public class GiveEveryoneRole : ModuleBase<SocketCommandContext>
    {
        [Command("GiveEveryoneRole")]
        [RequireOwner]
        public async Task HandleReact(SocketRole role)
        {
           foreach(var user in Context.Guild.Users)
           {
                foreach(var roles in user.Roles)
                {
                    if (roles.Name != role.Name)
                    {
                        await user.AddRoleAsync(role);
                    }
                }
           }
        }
    }
}

