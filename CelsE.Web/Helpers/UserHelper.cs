namespace CelsE.Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using CelsE.Web.Data.Entity;
    using CelsE.Web.Models;

    public class UserHelper : IUserHelper
    {
        #region Propiedades
        private readonly UserManager<UserEntity> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<UserEntity> signInManager;
        #endregion

        #region Constructor
        public UserHelper(UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserEntity> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        #endregion

        #region Métodos        
        //Nos devuelve si pudo o no entrar el usuario
        public async Task<IdentityResult> AddUserAsync(UserEntity user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

        //Añade un rol al usuario
        public async Task AddUserToRoleAsync(UserEntity user, string roleName)
        {
            await userManager.AddToRoleAsync(user, roleName);
        }

        //Busca el rol. Devuelve si existe o no. Sino existe, lo crea
        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<UserEntity> GetUserAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        //Nos devuelve el identificado de usuario a través del email
        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        //Pregunta si el usuario pertenece a un rol
        public async Task<bool> IsUserInRoleAsync(UserEntity user, string roleName)
        {
            return await userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await signInManager.PasswordSignInAsync(
                model.Usuario,
                model.Password,
                model.RememberMe,
                false); //false significa que no se bloquee el usuario con 3 intentos
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
        #endregion
    }
}
