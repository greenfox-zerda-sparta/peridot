﻿using EMail_Client_Beta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMail_Client_Beta
{
    public static class MailFetcherFactory
    {
        public static IEmailFetcher CreateClient(MailboxConnectionInfo connectionInfo)
        {
            switch(connectionInfo.Protocol)
            {
                case Protocol.POP3:
                    return new POP3MailFetcher(connectionInfo);
                case Protocol.IMAP:
                default:
                    return new IMAPMailFetcher(connectionInfo);
            }
        }
    }
}
