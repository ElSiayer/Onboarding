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
    public class VehiculoImplementacion : IVehiculo
    {
        private AppDbContext _context;

        public VehiculoImplementacion(AppDbContext context)
        {
            _context = context;
        }
        public Task<Vehiculo> GetVehiculoByPlaca(string placa) {
            Vehiculo vehiculo = _context.Vehiculo.Where(v=> v.Placa.Equals(placa)).FirstOrDefault();
            if (vehiculo != null) {
                return Task.FromResult(vehiculo);
            }
            throw new Exception($"No se encontro el Vehiculo con placa {placa}");

        }
        public Task<List<Vehiculo>> GetVehiculos() => Task.FromResult(_context.Vehiculo.ToList());
        public Task<List<Vehiculo>> GetVehiculosByMarca(int marcaId) => Task.FromResult(_context.Vehiculo.Where(v=>v.MarcaId == marcaId).ToList());
        public Task<List<Vehiculo>> GetVehiculosByModelo(string modelo) => Task.FromResult(_context.Vehiculo.Where(v => v.Modelo.Equals(modelo)).ToList());
        public void AddVehiculo(Vehiculo nuevoVehiculo) {
            Vehiculo vehiculo = _context.Vehiculo.Where(v => v.Placa.Equals(nuevoVehiculo.Placa)).FirstOrDefault();
            if (vehiculo == null)
            {
                try
                {
                    _context.Vehiculo.Add(nuevoVehiculo);
                    _context.SaveChanges();
                } catch {
                    throw new Exception($"Error al ingresar Vehiculo.");
                }
            }
            else {
                throw new Exception($"El Vehiculo con placa {nuevoVehiculo.Placa} ya esta registrado.");
            }
            
        }
        public void EditVehiculo(Vehiculo vehiculo) {
            Vehiculo original = _context.Vehiculo.Where(v => v.Placa.Equals(vehiculo.Placa)).FirstOrDefault();
            if (original != null) {
                original.Modelo = vehiculo.Modelo;
                original.NumChasis = vehiculo.NumChasis;
                original.MarcaId = vehiculo.MarcaId;
                original.Tipo = vehiculo.Tipo;
                original.Cilindraje = vehiculo.Cilindraje;
                original.Avaluo = vehiculo.Avaluo;
                _context.SaveChanges();
            }
            else {
                throw new Exception($"No se encontro el Vehiculo con placa {vehiculo.Placa}");
            }
            
        }
        public void DeleteVehiculoById(string placa) {
            Vehiculo vehiculo = _context.Vehiculo.Where(v => v.Placa.Equals(placa)).FirstOrDefault();
            if (vehiculo != null)
            {
                if (validateVehiculoOnCredito(placa)) {
                    _context.Vehiculo.Remove(vehiculo);
                    _context.SaveChanges();
                }

            }
            else {
                throw new Exception($"No se encontro el Vehiculo con placa {placa}");
            }
            
        }

        bool validateVehiculoOnCredito(string placa)
        {
            if (_context.Credito.Where(c => c.Placa.Equals(placa)).ToList().Count > 0)
            {
                throw new Exception($"No se puede eliminar el Vehiculo con placa: {placa} ya que tiene creditos asociados.");
            }
            return true;
        }


    }
}
