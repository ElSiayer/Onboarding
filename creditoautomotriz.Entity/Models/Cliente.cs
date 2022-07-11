using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Entity.Models
{
    public class Cliente
    {
        public Cliente() { }
        public Cliente(string identificacion, string nombres, string apellidos, int edad, DateTime fechaNacimiento, string direccion, string telefono, int estadoCivilId, bool sujetoCredito )
        {
            SujetoCredito = sujetoCredito;
            EstadoCivilId = estadoCivilId;
            Telefono = telefono;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            Edad = edad;
            Apellidos = apellidos;
            Nombres = nombres;
            Identificacion = identificacion;
        }

        [KeyAttribute]
        public string Identificacion { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }        
        public int Edad { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [ForeignKey("EstadoCivil")]
        public int EstadoCivilId { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public String IdentificacionConyugue { get; set; }
        public String NombreConyugue { get; set; }
        public bool SujetoCredito { get; set; }
    }
}
