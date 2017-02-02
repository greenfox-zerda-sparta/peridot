using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace EMail_Client_Beta.ViewModel
{
    public class ViewModelLocator
    {
        public MailboxConnectionInfo connectionInfo { get; set; }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IEmailFetcher>(() => new IMAPMailFetcher(connectionInfo));
            SimpleIoc.Default.GetInstance<IEmailFetcher>();

        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}