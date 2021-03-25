using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen1.Models
{
    public class Productos
    {
        public int codProd { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }
        [Required]
        public double precioUnit { get; set; }
        [Required]
        public int existencia { get; set; }
        [Required]
        public int garantia { get; set; }

        public Productos()
        {

        }

        public Productos(int codProd, string nombre, string descripcion, double precioUnit, int existencia, int garantia)
        {
            this.codProd = codProd;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precioUnit = precioUnit;
            this.existencia = existencia;
            this.garantia = garantia;
        }
    }
}