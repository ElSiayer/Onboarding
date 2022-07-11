using creditoautomotriz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface ICliente
    {
        Task<List<Cliente>> GetClientes();
        Task<Cliente> GetClienteById(string identificacion);
        void PostCliente(Cliente nuevoCliente);
        void EditCliente(Cliente cliente);
        void DeleteClienteById(string identificacion);
        
    }
}
