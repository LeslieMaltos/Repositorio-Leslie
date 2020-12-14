using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiendaFinal.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        [Display(Name = "Cliente")]
        [MaxLength(20, ErrorMessage = "Maximo 20 valores")]
        [Required(ErrorMessage ="Capture el Nombre")]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }
        [Display(Name ="Apellido Paterno")]
        [Required(ErrorMessage = "Capture el Apellido Paterno")]
        [MaxLength(14)]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "Capture el Apellido Paterno")]
        [MaxLength(14)]
        public string ApellidoMaterno { get; set; }
        [Phone]
        [Required(ErrorMessage = "Capture el Número De Telefono")]
        [MaxLength(250)]
        public string Telefono { get; set; }
        [MaxLength(250)]
        [Required(ErrorMessage = "Capture la Dirección")]
        public string Direccion { get; set; }
        [MaxLength(250)]
        [Required(ErrorMessage = "Capture el Correo Electronico")]
        [EmailAddress]
        public string CorreoElectronico { get; set; }
    }
}
    
