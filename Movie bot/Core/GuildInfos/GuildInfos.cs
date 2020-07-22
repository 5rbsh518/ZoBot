using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace Movie_bot.Core.GuildInfos
{
    public static class GuildInfos
    {
        private static List<GuildInfoa> Guildinfos;

        private static string GuildFile = "Resources/GuildInfos.json";

        static GuildInfos()
        {
            if (DataStorage.SaveExists(GuildFile))
            {
                Guildinfos = GuildInfoDS.LoadGuildInfo(GuildFile).ToList();
            }
            else
            {
                Guildinfos = new List<GuildInfoa>();
                SaveGuildInfo();
            }
        }

        public static void SaveGuildInfo()
        {
            GuildInfoDS.SaveGuildInfo(Guildinfos, GuildFile);
        }

        public static GuildInfoa GetGuild(SocketGuild guild)
        {
            return GetOrCreateGuildInfo(guild.Id);
        }

        private static GuildInfoa GetOrCreateGuildInfo(ulong id)
        {
            var result = from a in Guildinfos
                         where a.ID == id
                         select a;

            var guild = result.FirstOrDefault();
            if (guild == null) guild = CreateGuildInfo(id);
            return guild;
        }

        private static GuildInfoa CreateGuildInfo(ulong id)
        {
            var newguild = new GuildInfoa()
            {
                ID = id,
                movies = null,
                Voting = null,
                TicketNumber = 0,
                IstheCKonlyforowner = false
            };

            Guildinfos.Add(newguild);
            SaveGuildInfo();
            return newguild;
        }
    }
}
