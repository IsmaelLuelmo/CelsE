namespace CelsE.Web.Data.Entity
{
    using CelsE.Common;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class UserEntity : IdentityUser
    {
        #region Propiedades        
        [StringLength(9, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener {2} carácteres como mínimo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DNI { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener {1} carácteres como mínimo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido 1")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener {1} carácteres como mínimo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apellido1 { get; set; }

        [Display(Name = "Apellido 2")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener {1} carácteres como mínimo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apellido2 { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} debe tener {1} carácteres como mínimo.")]
        public string Direccion { get; set; }

        [Display(Name = "Fotografía")]
        public string FotoPath { get; set; }

        [Display(Name = "Tipo de usuario")]
        public UserType TipoUsuario { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido1} {Apellido2}";

        public string NombreCompletoConDocumento => $"{Nombre} {Apellido1} {Apellido2} - {DNI}";
        #endregion
    }
}
