using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiendaFinal.Models
{
    public class Perro
    {

        public int PerroId { get; set; }
        [Display(Name = "Nombre Del Perro")]
        [MaxLength(20, ErrorMessage = "Maximo 20 valores")]
        [Required(ErrorMessage = "Capture el Nombre")]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }
        [Display(Name = "Raza Del Perro")]
        [MaxLength(20, ErrorMessage = "Maximo 20 valores")]
        [Required(ErrorMessage = "Capture la Raza")]
        [Column(TypeName = "varchar")]
        public string Raza { get; set; }
        [Required(ErrorMessage = "Capture el Precio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Capture el sexo de la Mascota (M/H)")]
        [MaxLength(1, ErrorMessage = "Maximo 1 valor (M/H")]
        public string Sexo { get; set; }
        [Display(Name = "Fecha De Nacimiento")]
        [MaxLength(8, ErrorMessage = "Formato de fecha DD/MM/AA")]
        [Required(ErrorMessage = "Formato de fecha DD/MM/AA")]
        [Column(TypeName = "varchar")]
        public string FechaDeNacimiento { get; set; }


    }
}