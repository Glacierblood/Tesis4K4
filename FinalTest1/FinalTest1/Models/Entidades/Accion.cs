﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalTest1.Models.Entidades
{
    public class Accion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "No se permiten mas de 50 caracteres.")]
        [Display(Name = "Accion")]
        public String nombre { get; set; }

        [StringLength(150, ErrorMessage = "No se permiten mas de 150 caracteres.")]
        [Display(Name = "Caracteristicas")]
        public String descripcion { get; set; }

    }
}