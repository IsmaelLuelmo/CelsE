using Prism.Navigation;

namespace CelsE.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Página Principal";
        }
    }
}
