using FinalTest1.Models;
using FinalTest1.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTest1.ViewModel
{
    public class AdopcionViewModel 
    {
        public List<Animal> animal { get; set; }
        public Especie especie { get; set; }
        public Raza raza { get; set; }
        public ApplicationUser appUser{ get; set; }
        public List<TipoAdopcion> tipoAdopcion { get; set; }
        public Adopcion adopcion { get; set; }
    }
}