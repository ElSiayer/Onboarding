using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Entity.Models
{
    public class EstadoCredito
    {
        public EstadoCredito(string nombre) {
            Nombre = nombre;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EstadoCreditoId { get; set; }
        [Required]
        public string Nombre { get; set; }

    }
}
