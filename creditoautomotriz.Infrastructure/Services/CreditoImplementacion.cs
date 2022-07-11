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
    public class CreditoImplementacion :ICredito
    {
        private AppDbContext _context;

        public CreditoImplementacion(AppDbContext context)
        {
            _context = context;
        }
        public Task<List<Credito>> GetCreditos() => Task.FromResult(_context.Credito.ToList());
        public Task<Credito> GetCreditoByCreditoId(int creditoId) {

            Credito res = _context.Credito.Where(c => c.CreditoId ==creditoId).FirstOrDefault();
            if(res != null){
                return Task.FromResult(res);
            } else { 
                throw new Exception($"No se encontro el credito con el ID: {creditoId}"); 
            }            
            
        }
        public void AddCredito(Credito nuevoCredito) {
            if (validateDateCreditoCliente(nuevoCredito.ClienteId, nuevoCredito.FechaElaboracion)) {
                if (validateAvailabilityVehiculoCredito(nuevoCredito.Placa) && validateAvailabilityClienteCredito(nuevoCredito.ClienteId)) {
                    try {
                        _context.Credito.Add(nuevoCredito);
                        // Cuando se cree la solicitud se asocia el cliente a un patio.
                        validarAsignacionClientePatio(nuevoCredito.ClienteId, nuevoCredito.PuntoVenta);
                        _context.SaveChanges();
                    } catch {
                        throw new Exception($"No se pudo generar el credito.");
                    }                    
                }
            }            

        }

        void validarAsignacionClientePatio(string identificacionCliente, int patioId) {
            ClientePatio clientePatioval =_context.ClientePatio.Where(c => c.ClienteId.Equals(identificacionCliente)).Where(c => c.PatioId == patioId).FirstOrDefault();
            if (clientePatioval == null) {
                ClientePatio clientePatio = new ClientePatio();
                clientePatio.ClienteId = identificacionCliente;
                clientePatio.PatioId = patioId;
                clientePatio.FechaAsignacion =  DateTime.Now;
                _context.ClientePatio.Add(clientePatio);
            }
        }


        bool validateDateCreditoCliente(string clienteIdientificacion, DateTime fechaIngreso) {
            Credito ultimoCreditoCliente = _context.Credito.Where(c=>c.ClienteId.Equals(clienteIdientificacion)).OrderByDescending(c=>c.FechaElaboracion).OrderByDescending(c => c.CreditoId).FirstOrDefault();
            if(ultimoCreditoCliente != null && ultimoCreditoCliente.FechaElaboracion.Date == fechaIngreso.Date) {
                if( ultimoCreditoCliente.EstadoCreditoId == 1) {
                    throw new Exception($"Ya existe un credito activo para el cliente con identificacion {clienteIdientificacion}");
                }                    
            }
            return true;
        }

        bool validateAvailabilityVehiculoCredito(string placaVehiculo)
        {
            Credito vehiculoCredito = _context.Credito.Where(c => c.Placa.Equals(placaVehiculo)).OrderByDescending(c => c.FechaElaboracion).OrderByDescending(c => c.CreditoId).FirstOrDefault();
            if (vehiculoCredito != null && vehiculoCredito.EstadoCreditoId == 1)
            {
                throw new Exception($"El vehículo con placa {placaVehiculo} se encuentra en reserva.");
            }
            return true;
        }

        bool validateAvailabilityClienteCredito(string clienteIdientificacion)
        {
            Cliente cliente = _context.Cliente.Where(c => c.Identificacion.Equals(clienteIdientificacion)).FirstOrDefault();
            if (cliente != null && !cliente.SujetoCredito)
            {
                throw new Exception($"El cliente no puede puede realizar creditos.");
            }
            return true;
        }
    }
}
