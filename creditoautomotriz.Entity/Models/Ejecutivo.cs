using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Entity.Models
{
    public class Ejecutivo
    {
        public Ejecutivo() { }
        public Ejecutivo(string identificacion, string nombres, string apellidos, int edad, string direccion, string telefonoCon, string celular, int patioId)
        {
            Edad = edad;
            Apellidos = apellidos;
            Nombres = nombres;
            Identificacion = identificacion;
            Direccion = direccion;
            TelefonoCon = telefonoCon;
            Celular = celular;
            PatioId = patioId;
        }

        [Key]
        public string Identificacion { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Direccion { get; set; }
        public int Edad { get; set; }
        [Required]
        public string TelefonoCon { get; set; }
        [Required]
        public string Celular { get; set; }

        [ForeignKey("Patio")]
        public int PatioId { get; set; }
        public Patio Patio { get; set; }

    }
}
