using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_bot.Core.UserAccounts
{
    public class UserAccount
    {
        public ulong ID { get; set; }
        public string movies { get; set; }
        public int DozNumber { get; set;}
        public bool DozAccess { get; set; }
    }
}
