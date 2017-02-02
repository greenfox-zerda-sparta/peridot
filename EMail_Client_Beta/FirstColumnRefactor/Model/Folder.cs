using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EMail_Client_Beta.Model
{
    public class Folder : ObservableObject
    {
        private string folderName;
        private ObservableCollection<MailMessage> mailMessages;
        
        public string FolderName
        {
            get
            {
                return folderName;
            }

            set
            {
                Set(() => FolderName, ref folderName, value);
            }
        }

        public ObservableCollection<MailMessage> MailMessages
        {
            get
            {
                return mailMessages;
            }

            set
            {
                Set(() => MailMessages, ref mailMessages, value);
            }
        }
    }
}
