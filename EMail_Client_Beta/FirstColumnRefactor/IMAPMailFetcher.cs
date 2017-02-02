using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using EMail_Client_Beta.Model;
using System.Collections.ObjectModel;

namespace EMail_Client_Beta
{
    public class IMAPMailFetcher : EmailFetcher
    {
        private ImapClient client;

        public IMAPMailFetcher(MailboxConnectionInfo connectionInfo) : base(new ImapClient(), connectionInfo)
        {
            client = (ImapClient)service;
        }

        public override IList<Folder> GetFolders()
        {
            List<Folder> folders = new List<Folder>();
            Connect();            

            var allFolders = client.GetFolders(client.PersonalNamespaces[0]);
            foreach (var folder in allFolders)
            {
                ObservableCollection<Model.MailMessage> messages = new ObservableCollection<Model.MailMessage>();
                try
                {
                    folder.Open(FolderAccess.ReadWrite);
                    for (int i = 0; i < folder.Count; i++)
                    {
                        var message = folder.GetMessage(i);

                        messages.Insert(0, new Model.MailMessage()
                        {
                            Subject = message.Subject,
                            To = message.To.ToString(),
                            From = message.From.ToString(),
                            Date = message.Date.ToString(),
                            BodyText = message.TextBody
                        });
                    }
                    folders.Add(new Folder() { FolderName = folder.Name, MailMessages = messages });

                    folder.Close();
                }
                catch (ImapCommandException)
                {

                }
            }
            Disconnect();

            return folders;
        }

        public override IList<Model.MailMessage> GetMessages()
        {
            Model.MailMessage myMailMessage = new Model.MailMessage();
            List<Model.MailMessage> messages = new List<Model.MailMessage>();

            Connect();

            client.Inbox.Open(FolderAccess.ReadOnly);
            var fetchedMessages = client.Inbox.Fetch(0, -1, MessageSummaryItems.All);
            foreach (var message in fetchedMessages)
            {
                myMailMessage.Subject = message.Envelope.Subject;
                myMailMessage.To = message.Envelope.To.ToString();
                myMailMessage.From = message.Envelope.From.ToString();
                myMailMessage.Date = message.Envelope.Date.ToString();
            }

            Disconnect();

            return messages;
        }
    }
}
