using FinalTest1.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTest1.ViewModel
{
    public class Adopcion2Model
    {
        public List<Animal> animales { get; set; }
        public Adopcion adopcion { get; set; }

        public List<TipoAdopcion> tipoAdopcion { get; set; }
    }
}