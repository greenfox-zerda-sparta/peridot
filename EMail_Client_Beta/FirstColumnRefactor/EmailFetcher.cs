using EMail_Client_Beta.Model;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace EMail_Client_Beta
{
    public abstract class EmailFetcher : IEmailFetcher
    {
        protected MailService service;
        protected MailboxConnectionInfo connection;

        protected EmailFetcher(MailService service, MailboxConnectionInfo connection)
        {
            this.service = service;
            this.connection = connection;
        }

        protected void Connect()
        {
            if(!service.IsConnected)
            {
                service.Connect(connection.ServerAddress, connection.ServerPort);

                // In case of GMAIL
                if(service.AuthenticationMechanisms.Contains("XOAUTH2"))
                    service.AuthenticationMechanisms.Remove("XOAUTH2");

                service.Authenticate(connection.LoginName, connection.Password);
            }
        }

        private bool UseSSL()
        {
            return connection.Protocol == Protocol.IMAPS || connection.Protocol == Protocol.POP3S;
        }

        protected void Disconnect()
        {
            if(service.IsConnected)
            {
                service.Disconnect(true);
            }
        }

        public abstract IList<Folder> GetFolders();

        public abstract IList<Model.MailMessage> GetMessages();
    }
}
