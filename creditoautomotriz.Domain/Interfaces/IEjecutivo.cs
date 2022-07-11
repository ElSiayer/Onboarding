using creditoautomotriz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IEjecutivo
    {
        Task<List<Ejecutivo>> GetEjecutivos();
        Task<List<Ejecutivo>> GetEjecutivosByPatioId(int patioId);
        Task<Ejecutivo> GetEjecutivoById(string identificacion);
        void PostEjecutivo(Ejecutivo nuevoCliente);
        void EditEjecutivo(Ejecutivo cliente);
        void DeleteEjecutivoById(string identificacion);
    }
}
