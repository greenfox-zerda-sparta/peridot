using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using EMail_Client_Beta.Model;
using System.Collections.Generic;
using System.Windows;
using System;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace EMail_Client_Beta.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private Client client = new Client();

        ObservableCollection<Client> clients;
        ObservableCollection<Folder> folders;
        ObservableCollection<MailMessage> mailMessages;

        private Client selectedClient = new Client();
        private Folder selectedFolder = new Folder();
        private MailMessage selectedMailMessage = new MailMessage();
        public ICommand OnLoadedCommand { get; set; }

        public MainViewModel()
        {
            clients = new ObservableCollection<Client>();
            folders = new ObservableCollection<Folder>();
            mailMessages = new ObservableCollection<MailMessage>();
            OnLoadedCommand = new RelayCommand(OnLoaded);
        }

        public ObservableCollection<Folder> Folders
        {
            get { return folders; }
        }

        public ObservableCollection<Client> Clients
        {
            get { return clients; }
        }

        public ObservableCollection<MailMessage> MailMessages
        {
            get { return mailMessages; }
        }

        public Folder SelectedFolder
        {
            get { return selectedFolder; }
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

        public void OnLoaded()
        {
            client.EMailAddress = "zerdaspartaperidot@gmail.com";
            client.Password = "Frujudmat999";
            client.Protocol = Protocol.IMAP;
            client.ServerAddress = "imap.gmail.com";
            client.Port = 993;

            var fetcher = MailFetcherFactory.CreateClient(new MailboxConnectionInfo()
            {
                LoginName = client.EMailAddress,
                Password = client.Password,
                Protocol = client.Protocol,
                ServerAddress = client.ServerAddress,
                ServerPort = client.Port
            });

            var fetchedFolders = fetcher.GetFolders();
            foreach (var folder in fetchedFolders) { folders.Add(folder); }
            client.Folders = folders;
            clients.Add(client);
        }
    }
}