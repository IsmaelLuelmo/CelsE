namespace CelsE.Web.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ParteEntity
    {
        #region Propiedades        
        [Key]
        public int ID { get; set; }

        //Fecha local de dónde esté alojado el servidor
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha/hora de inicio")]
        [Required(ErrorMessage = "Introduzca fecha y hora")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime FechaInicio { get; set; }

        //Nuestra fecha local teniendo en cuenta la del servidor
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha/hora de inicio")]
        [Required(ErrorMessage = "Introduzca fecha y hora")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime FechaInicioLocal => FechaInicio.ToLocalTime();

        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        [DataType(DataType.MultilineText)]
        public string MedidasAdoptadas { get; set; }

        [DataType(DataType.MultilineText)]
        public string ComunicacionPadres { get; set; }

        //Con esta propiedad ya queda definido el profesor que pone el parte
        public ProfesorEntity Profesor { get; set; }

        public AlumnoEntity Alumno { get; set; }
        #endregion
    }
}
