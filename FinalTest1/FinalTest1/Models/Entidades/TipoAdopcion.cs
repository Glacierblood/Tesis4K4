using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalTest1.Models.Entidades
{
    public class TipoAdopcion
    {
        public int Id { get; set; }
        [Display(Name = "Tipo Adopcion")]
        public String nombre { get; set; }
        public String descripcion { get; set; }
    }
}