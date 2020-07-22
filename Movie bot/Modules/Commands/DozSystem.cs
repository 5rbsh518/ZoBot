using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Movie_bot.Modules;
using Movie_bot.Core;
using Movie_bot.Core.UserAccounts;
using Discord.Rest;

namespace Movie_bot.Modules.Commands
{
    public class DozSystem : ModuleBase<SocketCommandContext>
    {
        [Command("dozAccess")]
        [Alias("DA", "accessdoz")]
        [RequireOwner]
        public async Task dozAccess(SocketUser user)
        {
            var RGtarget = user;
            var RGgetuser = UserAccounts.GetAccount(user);
            if (RGgetuser.DozAccess)
            {
                RGgetuser.DozAccess = false;
                UserAccounts.SaveAccounts();
            }
            else
            {
                RGgetuser.DozAccess = true;
                UserAccounts.SaveAccounts();
            }
            
        }
        [Command("givedoz")]
        [Alias("Adddoz","GDz","AD","GD")]
        public async Task giveDoz(SocketUser RGuser, int lordnumber)
        {
            var ContextUser = Context.User;
            var getUser = UserAccounts.GetAccount(ContextUser);
            if(getUser.DozAccess)
            {
                if (lordnumber < 0)
                {
                    await Context.Channel.SendMessageAsync($"{Context.User.Mention} Are you stupid??????!, trying to give in negitive???");
                    return;
                }
                var RGtarget = RGuser;
                var RGgetuser = UserAccounts.GetAccount(RGtarget);
                RGgetuser.DozNumber += lordnumber;
                UserAccounts.SaveAccounts();
                IMessage message = await Context.Channel.SendMessageAsync("Done!");
                Thread.Sleep(500);
                await Context.Message.DeleteAsync();
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithTitle("NO Access");
                embed.WithColor(255, 0, 0);
                embed.WithDescription("You don't have access to use this command, trying to abuse or use this command more than once could cause in ban your account from RG community");
                embed.WithFooter("5rbsh518#5595", "https://cdn.discordapp.com/avatars/222459221235597312/a_a3cfe5c4da3f156aee7a9a868e0f1b24.gif?size=128");
                await Context.Channel.SendMessageAsync("", false, embed);
            }
                
        }
        [Command("mydoz")]
        [Alias("md", "checkdoz", "Doz")]
        public async Task HisDoz(SocketUser user)
        {
            var RGtarget = user;
            var RGgetuser = UserAccounts.GetAccount(RGtarget);
            await Context.Channel.SendMessageAsync($"{RGgetuser.DozNumber}");
        }
        [Command("mydoz")]
        [Alias("md", "checkdoz", "Doz")]
        public async Task mydoz()
        {
            var RGtarget = Context.User;
            var RGgetuser = UserAccounts.GetAccount(RGtarget);
            await Context.Channel.SendMessageAsync($"{RGgetuser.DozNumber}");
        }

        [Command("removedoz")]
        [Alias("dozremove", "RD", "DR", "deletedoz")]
        [RequireOwner]
        public async Task removedoz(SocketUser RGuser, int lordnumber)
        {
            var ContextUser = Context.User;
            var getUser = UserAccounts.GetAccount(ContextUser);
            if (getUser.DozAccess)
            {
                if (lordnumber < 0)
                {
                    await Context.Channel.SendMessageAsync($"{Context.User.Mention} Are you stupid??????!, trying to give in negitive???");
                    return;
                }
                var RGtarget = RGuser;
                var RGgetuser = UserAccounts.GetAccount(RGtarget);
                if(RGgetuser.DozNumber < lordnumber)
                {
                    var embed = new EmbedBuilder();
                    embed.WithTitle("Error");
                    embed.WithColor(255, 0, 0);
                    embed.WithDescription("You try to make an enitiy in nagative number which is unacceptable");
                    embed.WithFooter("5rbsh518#5595", "https://cdn.discordapp.com/avatars/222459221235597312/a_a3cfe5c4da3f156aee7a9a868e0f1b24.gif?size=128");
                    await Context.Channel.SendMessageAsync("", false, embed);
                    return;
                }
                RGgetuser.DozNumber -= lordnumber;
                UserAccounts.SaveAccounts();
                IMessage message = await Context.Channel.SendMessageAsync("Done!");
                Thread.Sleep(500);
                await Context.Message.DeleteAsync();
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithTitle("NO Access");
                embed.WithColor(255, 0, 0);
                embed.WithDescription("You don't have access to use this command, trying to abuse or use this command more than once could cause in ban your account from RG community");
                embed.WithFooter("5rbsh518#5595", "https://cdn.discordapp.com/avatars/222459221235597312/a_a3cfe5c4da3f156aee7a9a868e0f1b24.gif?size=128");
                await Context.Channel.SendMessageAsync("", false, embed);
            }
        }
        [Command("rghelp")]
        [Alias("RGH", "HelpRG")]
        public async Task RGHelp()
        {
            var embed = new EmbedBuilder();
            embed.WithColor(0, 0, 0);
            embed.AddInlineField("DozAccess", "To give access to a person to edit the members doz");
            embed.AddInlineField("GiveDoz", "To give someone doz's credit");
            embed.AddInlineField("\u200b", "\u200b");
            embed.AddInlineField("RemoveDoz", "To remove some doz for a memeber account");
            embed.AddInlineField("MyDoz", "To check how many doz you have");
            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}