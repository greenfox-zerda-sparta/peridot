using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EMail_Client_Beta.Model;
using System.Collections.ObjectModel;


namespace EMail_Client_Beta
{
    public interface IEmailFetcher
    {
        IList<Folder> GetFolders();
        IList<Model.MailMessage> GetMessages();
    }
}
