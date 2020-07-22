using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Webhook;
using Discord;

namespace Movie_bot
{
    internal static class Global
    {
        internal static DiscordSocketClient Client { get; set; }
    }
    internal static class GlobalVar
    {
        internal static int Runtime { get; set; }
        internal static ulong ID { get; set; }
        internal static string TheMostVotingID { get; set; }
        internal static ulong TheMostVote { get; set; }
        internal static ulong TheVotingNumber { get; set; }
        internal static string VotingID { get; set; }
        internal static SocketGuild ServerID { get; set; }
    }
}
