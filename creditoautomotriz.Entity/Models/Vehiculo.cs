using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Entity.Models
{
    public class Vehiculo
    {
        public Vehiculo() { }


        public Vehiculo(string placa, string modelo, string numChasis, int marcaId, string tipo, decimal cilindraje, decimal avaluo) {
            Placa = placa;
            Modelo = modelo;
            NumChasis = numChasis;
            MarcaId = marcaId;
            Tipo = tipo;
            Cilindraje = cilindraje;
            Avaluo = avaluo;
        }

        [Key]
        public string Placa { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string NumChasis { get; set; }
        [ForeignKey("Marca")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public string Tipo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cilindraje { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Avaluo { get; set; }

    }
}
