using Prism.Navigation;

namespace CelsE.Prism.ViewModels
{
    public class GroupPageViewModel : ViewModelBase
    {
       
        public GroupPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Grupo de alumnos";
            
        }
    }
}