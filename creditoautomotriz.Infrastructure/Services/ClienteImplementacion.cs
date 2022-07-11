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
    public class ClienteImplementacion : ICliente
    {
        private AppDbContext _context;

        public ClienteImplementacion(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Cliente>> GetClientes() => Task.FromResult(_context.Cliente.ToList());
        public Task<Cliente> GetClienteById(string identificacion) {
            Cliente res = _context.Cliente.Where(c => c.Identificacion.Equals(identificacion)).FirstOrDefault();
                if (res != null) {
                    return Task.FromResult(res);
                }
                throw new Exception($"No se encontro el cliente con el identificacion: {identificacion}");
        }
        public void PostCliente(Cliente nuevoCliente) {
            try
            {
                _context.Cliente.Add(nuevoCliente);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error al ingresar nuevo cliente.");
            }
        }
        public void EditCliente(Cliente cliente)
        {
            Cliente original = _context.Cliente.Where(c=> c.Identificacion.Equals(cliente.Identificacion)).FirstOrDefault();
            if (original != null)
            {
                original.Nombres = cliente.Nombres;
                original.Apellidos = cliente.Apellidos;
                original.Edad = cliente.Edad;
                original.FechaNacimiento = cliente.FechaNacimiento;
                original.Direccion = cliente.Direccion;
                original.Telefono = cliente.Telefono;
                original.EstadoCivilId = cliente.EstadoCivilId;
                original.IdentificacionConyugue = cliente.IdentificacionConyugue;
                original.NombreConyugue = cliente.NombreConyugue;
                original.SujetoCredito = cliente.SujetoCredito;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontro el cliente con la identificacion {cliente.Identificacion}.");
            }
        }
        public void DeleteClienteById(string identificacion)
        {
                Cliente cliente = _context.Cliente.Where(c => c.Identificacion.Equals(identificacion)).FirstOrDefault();
            if (cliente != null)
                {
                    if (validateClienteOnClientePatio(identificacion) && validateClienteOnCredito(identificacion)) {
                        _context.Cliente.Remove(cliente);
                        _context.SaveChanges();
                    }
                    
                }else {
                    throw new Exception($"No se encontro el cliente con identificacion: {identificacion}");
                }
            
            
        }
        bool validateClienteOnCredito(string identificacion) {
            if (_context.Credito.Where(c => c.ClienteId.Equals(identificacion)).ToList().Count>0) {
                throw new Exception($"No se puede eliminar el cliente con identificacion: {identificacion} ya que tiene creditos asociados.");
            }
            return true;
        }
        bool validateClienteOnClientePatio(string identificacion) {
            if (_context.ClientePatio.Where(c => c.ClienteId.Equals(identificacion)).ToList().Count > 0)
            {
                throw new Exception($"No se puede eliminar el cliente con identificacion: {identificacion} ya que tiene patios asociados.");
            }
            return true;

        }
    }
}
