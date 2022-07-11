using creditoautomotriz.Domain.Interfaces;
using creditoautomotriz.Entity.Models;
using creditoautomotriz.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Infrastructure.Services
{
    public class ClientePatioImplementacion : IClientePatio
    {
        private AppDbContext _context;

        public ClientePatioImplementacion(AppDbContext context)
        {
            _context = context;
        }
        public Task<ClientePatio> GetClientePatioByIds(string clientIdentificacion, int patioId) {

            ClientePatio res = _context.ClientePatio.Where(c => c.ClienteId == clientIdentificacion).Where(c => c.PatioId == patioId).FirstOrDefault();
            if(res != null) {
                return Task.FromResult(res);
            }
            else
            {
                throw new Exception($"No se encontro la asignacion solicitada.");
            }
            
        }
        public Task<List<ClientePatio>> GetClientePatioByPatioId(int patioId) {
            return Task.FromResult(_context.ClientePatio.Where(c => c.PatioId == patioId).ToList());
        }
        public Task<List<ClientePatio>> GetClientePatioByClienteId(string clientIdentificacion) {
            return Task.FromResult(_context.ClientePatio.Where(c => c.ClienteId == clientIdentificacion).ToList());
        }
        public void AddClientePatio(ClientePatio nuevoClientePatio) {
            ClientePatio clientePatioval = _context.ClientePatio.Where(c => c.ClienteId.Equals(nuevoClientePatio.ClienteId)).Where(c => c.PatioId == nuevoClientePatio.PatioId).FirstOrDefault();
            if (clientePatioval == null) {
                try {
                    _context.ClientePatio.Add(nuevoClientePatio);
                    _context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error al asignar el cliente al patio.");
                }
            }
            else
            {
                throw new Exception($"La asignacion solicitada ya existe.");
            }
        }
        public void EditClientePatio(ClientePatio clientePatio) {
            ClientePatio original = _context.ClientePatio.Where(c => c.ClienteId == clientePatio.ClienteId).Where(c => c.PatioId == clientePatio.PatioId).FirstOrDefault();
            if (original != null)
            {
                original.ClienteId = clientePatio.ClienteId;
                original.Cliente = clientePatio.Cliente;
                original.PatioId = clientePatio.PatioId;
                original.Patio = clientePatio.Patio;
                original.FechaAsignacion = clientePatio.FechaAsignacion;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro la asignacion requerida.");
            }
        }
        public void DeleteClientePatioByIds(string clientIdentificacion, int patioId) {
            ClientePatio clientePatio = _context.ClientePatio.Where(c => c.ClienteId == clientIdentificacion).Where(c => c.PatioId == patioId).FirstOrDefault();
            if (clientePatio != null)
            {
                _context.ClientePatio.Remove(clientePatio);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro la asignacion requerida.");
            }
        }
    }
}
