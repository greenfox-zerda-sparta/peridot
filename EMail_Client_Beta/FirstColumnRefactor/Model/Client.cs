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

        private string clientName;
        private ObservableCollection<Folder> folders;

        public string ClientName
        {
            get
            {
                return clientName;
            }

            set
            {
                Set(() => ClientName, ref clientName, value);
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
                folders = value;
            }
        }
    }
}
