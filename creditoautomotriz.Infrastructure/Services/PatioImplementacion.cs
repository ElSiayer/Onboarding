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
    public class PatioImplementacion : IPatio
    {
        private AppDbContext _context;

        public PatioImplementacion(AppDbContext context)
        {
            _context = context;
        }
        public Task<Patio> GetPatioById(int patioId) {
            Patio res = _context.Patio.Where(p=> p.PuntoVenta == patioId).FirstOrDefault();
            if (res != null) {
                return Task.FromResult(res);
                
            }
            throw new Exception("No se encontro el patio soliciatado");

        } 
        public Task<List<Patio>> GetPatios() => Task.FromResult(_context.Patio.ToList());
        public void AddPatio(Patio nuevoPatio) {
            Patio patio = _context.Patio.Where(p => p.PuntoVenta == nuevoPatio.PuntoVenta).FirstOrDefault();
            if (patio == null)
            {
                try
                {
                    _context.Patio.Add(nuevoPatio);
                    _context.SaveChanges();
                }
                catch
                {
                    throw new Exception("Error al ingresar el Patio.");
                }
            }else {
                throw new Exception($"Ya existe el patio con el punto de venta {nuevoPatio.PuntoVenta}");
            }

            
        }
        public void EditPatio(Patio patio) {
            Patio original = _context.Patio.Where(p => p.PuntoVenta == patio.PuntoVenta).FirstOrDefault();
            if (original != null)
            {
                original.Nombre = patio.Nombre;
                original.Direccion = patio.Direccion;
                original.Telefono = patio.Telefono;
                _context.SaveChanges();
            }else {
                throw new Exception($"No se encontro el patio soliciatado");
            }
            
        }
        public void DeletePatioById(int patioId)
        {
            Patio patio = _context.Patio.Where(p => p.PuntoVenta == patioId).FirstOrDefault();
            if (patio != null)
            {
                if (validatePatioOnClientePatio(patioId) && validatePatioOnCredito(patioId) && validatePatioOnEjecutivo(patioId)) {
                    _context.Patio.Remove(patio);
                    _context.SaveChanges();
                }

            }
            else {
                throw new Exception($"No se encontro el patio soliciatado");
            }
            
        }
        bool validatePatioOnCredito(int patioId)
        {
            if (_context.Credito.Where(c => c.PuntoVenta == patioId).ToList().Count > 0)
            {
                throw new Exception($"No se puede eliminar el patio con punto de venta: {patioId} ya que tiene creditos asociados.");
            }
            return true;
        }
        bool validatePatioOnClientePatio(int patioId)
        {
            if (_context.ClientePatio.Where(c => c.PatioId == patioId).ToList().Count > 0)
            {
                throw new Exception($"No se puede eliminar el patio con punto de venta: {patioId} ya que tiene clientes asociados.");
            }
            return true;

        }

        bool validatePatioOnEjecutivo(int patioId)
        {
            if (_context.Ejecutivo.Where(c => c.PatioId == patioId).ToList().Count > 0)
            {
                throw new Exception($"No se puede eliminar el patio con punto de venta: {patioId} ya que tiene ejecutivos asociados.");
            }
            return true;

        }
    }
}
