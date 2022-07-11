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
    public class EjecutivoImplementacion : IEjecutivo
    {
        private AppDbContext _context;

        public EjecutivoImplementacion(AppDbContext context)
        {
            _context = context;
        }
        public Task<List<Ejecutivo>> GetEjecutivos() => Task.FromResult(_context.Ejecutivo.ToList());
        public Task<List<Ejecutivo>> GetEjecutivosByPatioId(int patioId) => Task.FromResult(_context.Ejecutivo.Where(e => e.PatioId == patioId).ToList());
        public Task<Ejecutivo> GetEjecutivoById(string identificacion) {
            Ejecutivo res = _context.Ejecutivo.Where(e => e.Identificacion == identificacion).FirstOrDefault();
            if (res != null) {
                return Task.FromResult(res);
            }else
            {
                throw new Exception($"No se encontro el ejecutivo con identificacion: {identificacion}");
            }
        } 
        public void PostEjecutivo(Ejecutivo nuevoEjecutivo) {
            Ejecutivo ejecutivo = _context.Ejecutivo.Where(e => e.Identificacion == nuevoEjecutivo.Identificacion).FirstOrDefault();
            if (ejecutivo == null) {
                _context.Ejecutivo.Add(nuevoEjecutivo);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Ya existe un ejecutivo con la identificacion {nuevoEjecutivo.Identificacion}.");
            }
            
        }
        public void EditEjecutivo(Ejecutivo ejecutivo) {
            Ejecutivo original = _context.Ejecutivo.Where(e => e.Identificacion.Equals(ejecutivo.Identificacion)).FirstOrDefault();
            if (original != null)
            {
                original.Nombres = ejecutivo.Nombres;
                original.Apellidos = ejecutivo.Apellidos;
                original.Direccion = ejecutivo.Direccion;
                original.Edad = ejecutivo.Edad;
                original.TelefonoCon = ejecutivo.TelefonoCon;
                original.Celular = ejecutivo.Celular;
                original.PatioId = ejecutivo.PatioId;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontro el ejecutivo con la identificacion {ejecutivo.Identificacion}.");
            }
        }
        public void DeleteEjecutivoById(string identificacion) {
            Ejecutivo ejecutivo = _context.Ejecutivo.Where(e => e.Identificacion.Equals(identificacion)).FirstOrDefault();
            if (ejecutivo != null)
            {
                _context.Ejecutivo.Remove(ejecutivo);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontro el ejecutivo con la identificacion {ejecutivo.Identificacion}.");
            }
        }        
    }
}
