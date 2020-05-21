using Prism.Navigation;


namespace CelsE.Prism.ViewModels
{
    public class CelsEHistoryPageViewModel : ViewModelBase
    {
        public CelsEHistoryPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Historial del alumno";
        }
    }
}
