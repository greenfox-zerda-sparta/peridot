using EMail_Client_Beta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMail_Client_Beta
{
    public class MailboxConnectionInfo
    {
        public string ServerAddress { get; set; }

        public int ServerPort { get; set; }

        public Protocol Protocol { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }
    }
}
