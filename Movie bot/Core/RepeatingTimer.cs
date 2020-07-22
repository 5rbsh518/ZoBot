using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Discord.WebSocket;

namespace Movie_bot
{
    internal static class Repeating
    {
        private static Timer Loopingtimer;
        private static SocketTextChannel Channel;
        private static SocketGuildUser User;
        internal static Task StartTimer()
        {
            Channel = Global.Client.GetGuild(516707931211694093).GetTextChannel(516707931211694097);
            User = Global.Client.GetGuild(516707931211694093).GetUser(222459221235597312);
            Loopingtimer = new Timer()
            {
                Interval = 1000,
                AutoReset = true,
                Enabled = true,
            };
            Loopingtimer.Elapsed += Timerticked;
            return Task.CompletedTask;
        }

        private static async void Timerticked(object sender, ElapsedEventArgs e)
        {
            
        }
    }
}
