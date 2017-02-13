using EMail_Client_Beta.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace EMail_Client_Beta.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();

            //SimpleIoc.Default.Register<IEmailFetcher>(() => new IMAPMailFetcher(connectionInfo));
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        //public IMAPMailFetcher Fetcher
        //{
        //    get { return ServiceLocator.Current.GetInstance<IMAPMailFetcher>(); }
        //}
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}