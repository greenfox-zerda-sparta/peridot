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
            
            Disconnect();

            return folders;
        }

        public override IList<Model.MailMessage> GetMessages()
        {
            List<Model.MailMessage> mailmessages = new List<Model.MailMessage>();

            Connect();

            for (int i = 0; i < client.Count; i++)
            {
                Model.MailMessage mailMessage = new Model.MailMessage();
                var message = client.GetMessage(i);
                mailMessage.BodyText = message.TextBody;
                mailMessage.Date = message.Date.ToString();
                mailMessage.From = message.From.ToString();
                mailMessage.Subject = message.Subject;
                mailMessage.To = message.To.ToString();
            }

            Disconnect();

            return new List<Model.MailMessage>();
        }
    }
}
