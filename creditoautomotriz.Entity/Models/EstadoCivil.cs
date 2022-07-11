using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Entity.Models
{
    public class EstadoCivil
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EstadoCivilId { get; set; }
        [Required]
        public string Estado { get; set; }

        public EstadoCivil(string estado)
        {
            Estado = estado;
        }
        public EstadoCivil() { }
    }
}
