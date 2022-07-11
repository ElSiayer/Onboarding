using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Entity.Models
{
    public class Credito
    {
        public Credito() { }
        public Credito(DateTime fechaElaboracion, string clienteId, int puntoVenta, string placa, int mesesPlazo, decimal cuotas, decimal entrada, int estadoCredito,string ejecutivoId) {
            FechaElaboracion = fechaElaboracion;
            ClienteId = clienteId;
            PuntoVenta = puntoVenta;
            Placa = placa;
            MesesPlazo = mesesPlazo;
            Cuotas = cuotas;
            Entrada = entrada;
            EstadoCreditoId = estadoCredito;
            EjecutivoId = ejecutivoId;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CreditoId { get; set; }
        [Required]
        public DateTime FechaElaboracion { get; set; }

        [ForeignKey("Cliente")]
        public string ClienteId { get; set; }   
        public Cliente Cliente { get; set; }

        [ForeignKey("Patio")]
        public int PuntoVenta { get; set; }
        public Patio Patio { get; set; }

        [ForeignKey("Vehiculo")]
        public string Placa { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public int MesesPlazo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cuotas { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Entrada { get; set; }

        [ForeignKey("EstadoCredito")]
        public int EstadoCreditoId { get; set; }
        public EstadoCredito EstadoCredito { get; set; }

        [ForeignKey("Ejecutivo")]
        public string EjecutivoId { get; set; }
        public Ejecutivo Ejecutivo { get; set; }

        public string Observacion { get; set; }
    }
}
