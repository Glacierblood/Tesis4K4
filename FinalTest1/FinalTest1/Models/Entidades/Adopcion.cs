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

       
        [StringLength(128)]
        public String admId { get; set; }

        public int tipoAdopcionId { get; set; }
        public TipoAdopcion tipoAdopcion { get; set; }

        public int estadoAdopcionId { get; set; }
        public EstadoAdopcion estadoAdopcion { get; set; }

        public Boolean esTemporal { get; set; }

        public DateTime fechaAlta { get; set; }
        public DateTime fechaBaja { get; set; }
        public DateTime fechaConfirmacion { get; set; }
        public DateTime fechaCancelacion { get; set; }
        public DateTime fechaEntrega { get; set; }
        public DateTime fechaFin { get; set; }

        public float importe { get; set; }

        public DateTime fechaFinColaboracion { get; set; }
        

    }
}