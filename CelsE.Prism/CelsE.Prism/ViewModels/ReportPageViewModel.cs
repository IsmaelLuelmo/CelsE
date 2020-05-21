using Prism.Navigation;

namespace CelsE.Prism.ViewModels
{
    public class ReportPageViewModel : ViewModelBase
    {
        public ReportPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Reportar incidencia";
        }
    }
}