using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMail_Client_Beta.Model
{
    public class Client : ObservableObject
    {

        private string eMailAddress;
        private string password;
        private Protocol protocol;
        private string serverAddress;
        private int port;

        private ObservableCollection<Folder> folders;

        public string EMailAddress
        {
            get
            {
                return eMailAddress;
            }

            set
            {
                Set(() => EMailAddress, ref eMailAddress, value);
            }
        }

        public ObservableCollection<Folder> Folders
        {
            get
            {
                return folders;
            }

            set
            {
                Set(() => Folders, ref folders, value);
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                Set(() => Password, ref password, value);
            }
        }

        public Protocol Protocol
        {
            get
            {
                return protocol;
            }

            set
            {
                Set(() => Protocol, ref protocol, value);
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                Set(() => Port, ref port, value);
            }
        }

        public string ServerAddress
        {
            get
            {
                return serverAddress;
            }

            set
            {
                Set(() => ServerAddress, ref serverAddress, value);
            }
        }
    }
}
