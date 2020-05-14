namespace CelsE.Web.Helpers
{
    using CelsE.Web.Data.Entity;
    using CelsE.Web.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public interface IUserHelper
    {
        #region Métodos
        //Devuelve el usuario del email
        Task<UserEntity> GetUserByEmailAsync(string email);

        //Devuelve un usuario ID al intentar añadir uno nuevo
        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        //Verificar el rol y lo crea si no existe
        Task CheckRoleAsync(string roleName);

        //Matricula el usuario en ese rol
        Task AddUserToRoleAsync(UserEntity user, string roleName);

        //Dice si el usuario pertenece o no a un rol
        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);

        Task<UserEntity> GetUserAsync(string email);

        //Método para el login
        Task<SignInResult> LoginAsync(LoginViewModel model);

        //Método para logout
        Task LogoutAsync();
        #endregion
    }
}
