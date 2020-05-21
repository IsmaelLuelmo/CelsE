using CelsE.Common.Models;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CelsE.Prism.ViewModels
{
    public class CelsEMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public CelsEMasterDetailPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_airport_shuttle",
                    PageName = "HomePage",
                    Title = "Nuevo viaje"
                },
                new Menu
                {
                    Icon = "ic_local_taxi",
                    PageName = "CelsEHistoryPage",
                    Title = "Historial"
                },
                new Menu
                {
                    Icon = "ic_people",
                    PageName = "GroupPage",
                    Title = "Grupo"
                },
                new Menu
                {
                    Icon = "ic_account_circle",
                    PageName = "ModifyUserPage",
                    Title = "Usuarios"
                },
                new Menu
                {
                    Icon = "ic_report",
                    PageName = "ReportPage",
                    Title = "Incidente"
                },
                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Login"
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }

}
