using Prism.Navigation;

namespace CelsE.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Login";
        }
    }
}