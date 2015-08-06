using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalTest1.Models.Entidades
{
    public class Adopcion
    {
        public int Id { get; set; }

        
        [StringLength(128)]
        public String voluntarioId { get; set; }
        [Display(Name = "Voluntario")]
        public String nombreVoluntario { get; set; }
        [Required]
        [Display(Name = "Animal")]
        public int? animalId { get; set; }
        public Animal animal { get; set; }
       
        [StringLength(128)]
        public String admId { get; set; }
        [Display(Name = "Administrador")]
        public String nombreAdm { get; set; }

        [Display(Name = "Tipo Adopcion")]
        public int? tipoAdopcionId { get; set; }
        public TipoAdopcion tipoAdopcion { get; set; }

        [Display(Name = "Estado")]
        public int estadoAdopcionId { get; set; }
        public EstadoAdopcion estadoAdopcion { get; set; }

        [Display(Name = "Temporal")]
        public Boolean? esTemporal { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Alta")]
        public DateTime? fechaAlta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Baja")]
        public DateTime? fechaBaja { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Confirmacion")]
        public DateTime? fechaConfirmacion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cancelacion")]
        public DateTime? fechaCancelacion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Entrega")]
        public DateTime? fechaEntrega { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fin Adopcion")]
        public DateTime? fechaFin { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Importe")]
        public float? importe { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fin Colaboracion")]
        public DateTime? fechaFinColaboracion { get; set; }
        

    }
}