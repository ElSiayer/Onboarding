using creditoautomotriz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IClientePatio
    {
        Task<ClientePatio> GetClientePatioByIds(string clientIdentificacion, int patioId);
        Task<List<ClientePatio>> GetClientePatioByPatioId(int patioId);
        Task<List<ClientePatio>> GetClientePatioByClienteId(string clientIdentificacion);
        void AddClientePatio(ClientePatio nuevoClientePatio);
        void EditClientePatio(ClientePatio clientePatio);
        void DeleteClientePatioByIds(string identificacion, int patioId);
    }
}
