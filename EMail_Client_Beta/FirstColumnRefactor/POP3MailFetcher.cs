using EMail_Client_Beta.Model;
using MailKit.Net.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EMail_Client_Beta
{
    public class POP3MailFetcher : EmailFetcher
    {
        private Pop3Client client;

        public POP3MailFetcher(MailboxConnectionInfo connectionInfo) : base(new Pop3Client(), connectionInfo)
        {
            client = (Pop3Client)service;
        }

        public override IList<Folder> GetFolders()
        {
            List<Folder> folders = new List<Folder>();

            Connect();
            
            //need to declare what this function does, actually there are no folders in POP3, just inbox
            //maybe get messages would be more clear, even for IMAP

            Disconnect();

            return folders;
        }
    }
}
