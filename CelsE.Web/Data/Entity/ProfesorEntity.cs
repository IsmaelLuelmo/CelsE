namespace CelsE.Web.Data.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProfesorEntity
    {
        #region Propiedades        
        [Key]
        public int ID { get; set; }

        [StringLength(9, MinimumLength = 8, ErrorMessage = "El campo {0} debe tener {2} carácteres como mínimo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DNI { get; set; }

        [RegularExpression(@"^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$", ErrorMessage = "{0}: Debe cuidar las mayúsculas y no introducir números, símobolos, etc (por ej: Pedro De La Hoz)")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener {2} carácteres como mínimo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [RegularExpression(@"^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$", ErrorMessage = "{0}: Debe cuidar las mayúsculas y no introducir números, símobolos, etc (por ej: Pedro De La Hoz)")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener {2} carácteres como mínimo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apellidos { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Formato teléfono no válido")]
        public string TelefonoProfesor { get; set; }

        [EmailAddress]
        public string EmailProfesor { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        //Conjunto de partes del profesor
        public ICollection<ParteEntity> Partes { get; set; }

        public UserEntity Usuario { get; set; }
        #endregion
    }
}
