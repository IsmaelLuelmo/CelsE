using Prism.Navigation;

namespace CelsE.Prism.ViewModels
{
    public class ModifyUserPageViewModel : ViewModelBase
    {
        public ModifyUserPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Datos del usuario";
        }
    }
}