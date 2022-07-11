using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Entity.Models
{
    public class ClientePatio
    {
        [Key]
        [Column(Order = 1)]
        public int PatioId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ClienteId { get; set; }


        [ForeignKey("PatioId")]   
        public Patio Patio { get; set; }

        [ForeignKey("ClienteId")]        
        public Cliente Cliente { get; set; }
        [Required]

        public DateTime FechaAsignacion { get; set;}
    }
}
