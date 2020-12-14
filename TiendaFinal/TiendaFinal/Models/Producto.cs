using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiendaFinal.Models
{
    public class Producto
    {

        public int ProductoId { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Capture el Nombre")]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Capture el Precio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Capture el Proveedor")]
        [MaxLength(50)]
        public string Proveedor { get; set; }
        [Required(ErrorMessage = "Capture la cantidad disponible en stock")]
        public int CantidadStock { get; set; }

    }
}