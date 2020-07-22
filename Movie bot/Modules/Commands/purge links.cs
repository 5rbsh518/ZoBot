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

namespace Movie_bot.Modules
{
    public class Purge : ModuleBase<SocketCommandContext>
    {
        [Command("PurgeLink")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task PurgeLink(int PurgeNumber)
        {
            int amount = PurgeNumber;

            while (amount != 0)
            {
                if (amount >= 100)
                {
                    var messages = await Context.Channel.GetMessagesAsync(100).Flatten();
                    foreach (var message in messages)
                    {
                        string messagecont = message.Content;
                        if (messagecont.IndexOf("https://", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            await message.DeleteAsync();
                        }
                    }

                    amount = amount - 100;
                }
                else
                {
                    var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
                    foreach (var message in messages)
                    {
                        string messagecont = message.Content;
                        if (messagecont.IndexOf("https://", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = 0;
                }
            }
        }
        [Command("Purge")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task PurgeAll(int PurgeNumber)
        {
            int amount = PurgeNumber;

            while (amount != 0)
            {
                if (amount >= 100)
                {
                    var messages = await Context.Channel.GetMessagesAsync(100).Flatten();
                    foreach (var message in messages)
                    {
                        await message.DeleteAsync();
                    }
                    amount = amount - 100;
                }
                else
                {
                    var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
                    foreach (var message in messages)
                    {
                        await message.DeleteAsync();
                    }
                    amount = 0;
                }

            }
        }
        [Command("PurgeText")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task PurgeText(int PurgeNumber)
        {
            int amount = PurgeNumber;

            while (amount != 0)
            {
                if (amount >= 100)
                {
                    var messages = await Context.Channel.GetMessagesAsync(100).Flatten();
                    foreach (var message in messages)
                    {
                        if (message.Embeds.Count == 0)
                        {
                            if (message.Content.IndexOf("https://", 0, StringComparison.CurrentCultureIgnoreCase) == -1)
                            {
                                await message.DeleteAsync();
                            }
                        }
                    }
                    amount = amount - 100;
                }
                else
                {
                    var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
                    foreach (var message in messages)
                    {
                        if (message.Embeds.Count == 0)
                        {
                            if (message.Content.IndexOf("https://", 0, StringComparison.CurrentCultureIgnoreCase) == -1)
                            {
                                await message.DeleteAsync();
                            }
                        }
                    }
                    amount = 0;
                }

            }
        }
        [Command("PurgeWord")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task PurgeWord(int PurgeNumber, [Remainder]string TheWord)
        {
            int amount = PurgeNumber;

            while (amount != 0)
            {
                if (amount >= 100)
                {
                                var messages = await Context.Channel.GetMessagesAsync(100).Flatten();
                  foreach (var message in messages)
                  {
                     if (message.Content.IndexOf(TheWord, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                     {
                       await message.DeleteAsync();
                     }
                  }  
                    amount = amount - 100;
                }
                else
                {
                    var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
                    foreach (var message in messages)
                    {
                        if (message.Content.IndexOf(TheWord, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = 0;
                }

            }
        }
        [Command("PurgeUser")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task PurgeUser(IGuildUser user, int PurgeNumber)
        {
            int amount = PurgeNumber;

            while (amount != 0)
            {
                if (amount >= 100)
                {
                    var messages = await Context.Channel.GetMessagesAsync(100).Flatten();
                    foreach (var message in messages)
                    {
                        if (message.Author.Id == user.Id)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = amount - 100;
                }
                else
                {
                    var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
                    foreach (var message in messages)
                    {
                        if (message.Author.Id == user.Id)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = 0;
                }

            }
        }
        [Command("PurgeAll")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task PurgeAll()
        {
            int Amount = 0;
            while (Amount < 1)
            {
                var messages = await Context.Channel.GetMessagesAsync(100).Flatten();
                if (messages.Count() != 0)
                {
                    foreach (var message in messages)
                    {
                        await message.DeleteAsync();
                    }
                }
                else
                {
                    break;
                }
            }  
        }
        [Command("Purgeembed")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task Purgeembed(int number)
        {
            int amount = number;
            while(amount != 0)
            {
                if(amount >= 100)
                {
                    var messages = await Context.Channel.GetMessagesAsync(100).Flatten();
                    foreach(var message in messages)
                    {
                        if(message.Embeds.Count > 0)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = amount - 100;
                }
                else
                {
                    var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
                    foreach(var message in messages)
                    {
                        if(message.Embeds.Count > 0)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = 0;
                }
                
            }
        }
        [Command("Purgebots")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task PurgeBots(int number)
        {
            int amount = number;
            while(amount != 0)
            {
                if (amount >= 100)
                {
                    var messages = await Context.Channel.GetMessagesAsync(100).Flatten();
                    foreach(var message in messages)
                    {
                        if(message.Author.IsBot)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = amount - 100;
                }
                else
                {
                    var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
                    foreach(var message in messages)
                    {
                        if(message.Author.IsBot)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = 0;
                }
            }
        }
        [Command("PurgeMention")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task PurgeMentions(int number)
        {
            int amount = number;
            while(amount != 0)
            {
                if (amount >= 100)
                {
                    var messages = await Context.Channel.GetMessagesAsync(100).Flatten();
                    foreach(var message in messages)
                    {
                        if(message.MentionedUserIds.Count > 0 ||message.MentionedRoleIds.Count > 0 || message.MentionedChannelIds.Count > 0 )
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = amount - 100;
                }
                else
                {
                    var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
                    foreach(var message in messages)
                    {
                        if (message.MentionedUserIds.Count > 0 || message.MentionedRoleIds.Count > 0 || message.MentionedChannelIds.Count > 0)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    amount = 0;
                }
            }
        }
    }
}
