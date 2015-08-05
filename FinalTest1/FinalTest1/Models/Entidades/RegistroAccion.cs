using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalTest1.Models.Entidades
{
    public class RegistroAccion
    {
        public int Id { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaBaja { get; set; }

        public Boolean esHabilitado { get; set; }

        public String comentario { get; set; }
        
        public int accionId { get; set; }
        public Accion accion { get; set; }

        [Required]
        [StringLength(128)]
        public String usrId { get; set; }
        

        
    }
}