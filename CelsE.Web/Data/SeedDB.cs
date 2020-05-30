namespace CelsE.Web.Data
{
    using CelsE.Common;
    using CelsE.Web.Data.Entity;
    using CelsE.Web.Helpers;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        #region Propiedades
        private DataContext DataContext { get; }
        private readonly IUserHelper userHelper;
        #endregion

        #region Contructores
        public SeedDb(DataContext dataContext, IUserHelper userHelper)
        {
            this.DataContext = dataContext;
            this.userHelper = userHelper;
        }
        #endregion

        #region Métodos
        public async Task SeedAsync()
        {
            //Comprueba la BBDD, la crea, modifica, etc
            await DataContext.Database.EnsureCreatedAsync();
            //Chequea y matricula los 3 roles creados
            await CheckRolesAsync();
            //Ahora creamos los usuarios
            var admin = await CheckUserAsync("48347524Y", "Ismael", "Luelmo", "Seguí", "usuario@gmail.com", "660984094", "Calle Arquitecto Vidal", UserType.Admin);
            await CheckBBDDAsync();
        }

        private async Task CheckRolesAsync()
        {
            //Si estos roles no existen, los crea
            await userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await userHelper.CheckRoleAsync(UserType.Profesor.ToString());
            await userHelper.CheckRoleAsync(UserType.Alumno.ToString());
            await userHelper.CheckRoleAsync(UserType.Invitado.ToString());
        }

        private async Task CheckBBDDAsync()
        {
            if (DataContext.Profesor.Any())
            {
                return;
            }

            //No hay ningún alumno, creo uno
            //****

            //Hacemos commit
            await DataContext.SaveChangesAsync();
        }

        //Méotod para chequear y crear usuario sino existe
        private async Task<UserEntity> CheckUserAsync(
            string dni,
            string nombre,
            string apellido1,
            string apellido2,
            string email,
            string telefono,
            string direccion,
            UserType tipoUsuario)
        {
            UserEntity user = await userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    Nombre = nombre,
                    Apellido1 = apellido1,
                    Apellido2 = apellido2,
                    Email = email,
                    UserName = email,
                    PhoneNumber = telefono,
                    Direccion = direccion,
                    DNI = dni,
                    TipoUsuario = tipoUsuario
                };

                await userHelper.AddUserAsync(user, "123456");
                await userHelper.AddUserToRoleAsync(user, tipoUsuario.ToString());
            }
            return user;
        }
        #endregion

    }
}
