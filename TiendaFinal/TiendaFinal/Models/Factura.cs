using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiendaFinal.Models
{
    public class Factura
    {

        public int FacturaId { get; set; }
        [Display(Name = "Id Producto")]
        [Required(ErrorMessage ="Captura el Id del Producto/Mascota")]
        public int ItemId { get; set; }
        [Display(Name = "Id Cliente")]
        [Required(ErrorMessage = "Captura el Id del Cliente")]
        public int ClienteId { get; set; }
        [MaxLength(200, ErrorMessage = "Maximo 200 valores")]
        [Required(ErrorMessage = "Capture una descripción del producto/Mascota")]
        [Column(TypeName = "varchar")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Captura la cantidad de productos")]
        public int Cantidad { get; set; }
        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "Captura el Precio por unidad")]
        public decimal PrecioUnitario { get; set; }
        [Required(ErrorMessage = "Captura el total")]
        public decimal Total { get; set; }

    }
}