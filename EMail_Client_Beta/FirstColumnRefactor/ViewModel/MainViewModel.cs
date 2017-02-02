using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using EMail_Client_Beta.Model;
using System.Collections.Generic;
using System.Linq;

namespace EMail_Client_Beta.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private MailboxConnectionInfo connectionInfo = new MailboxConnectionInfo();

        ObservableCollection<Client> clients;
        ObservableCollection<Folder> folders;
        ObservableCollection<MailMessage> mailMessages;
        private Client selectedClient = new Client();
        private Folder selectedFolder = new Folder();
        private MailMessage selectedMailMessage = new MailMessage();

        public MainViewModel()
        {
            clients = new ObservableCollection<Client>();
            folders = new ObservableCollection<Folder>();
            mailMessages = new ObservableCollection<MailMessage>();

            connectionInfo.LoginName = "zerdaspartaperidot@gmail.com";
            connectionInfo.Password = "Frujudmat999";
            connectionInfo.Protocol = Protocol.IMAP;
            connectionInfo.ServerAddress = "imap.gmail.com";
            connectionInfo.ServerPort = 993;
            IMAPMailFetcher imapFetch = new IMAPMailFetcher(connectionInfo);
            var thisFolders = imapFetch.GetFolders();
            foreach(var folder in thisFolders)
            {
                folders.Add(folder);
            }
            clients.Add(new Client() { ClientName = connectionInfo.LoginName, Folders = folders });
        }

        public ObservableCollection<Folder> Folders
        {
            get { return folders; }
        }

        public Folder SelectedFolder
        {
            get
            {
                return selectedFolder;
            }
            set
            {
                selectedFolder = value;
                RaisePropertyChanged(() => SelectedFolder);
            }
        }

        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                RaisePropertyChanged(() => SelectedClient);
            }
        }

        public MailMessage SelectedMailMessage
        {
            get { return selectedMailMessage; }
            set
            {
                selectedMailMessage = value;
                RaisePropertyChanged(() => SelectedMailMessage);
            }
        }

        public ObservableCollection<Client> Clients
        {
            get { return clients; }
        }

        public ObservableCollection<MailMessage> MailMessages
        {
            get { return mailMessages; }
        }
    }
}