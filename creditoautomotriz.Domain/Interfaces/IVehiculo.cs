using creditoautomotriz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IVehiculo
    {
        Task<Vehiculo> GetVehiculoByPlaca(string placa);
        Task<List<Vehiculo>> GetVehiculos();
        Task<List<Vehiculo>> GetVehiculosByMarca(int marcaId);
        Task<List<Vehiculo>> GetVehiculosByModelo(string modelo);
        void AddVehiculo(Vehiculo nuevoVehiculo);
        void EditVehiculo(Vehiculo vehiculo);
        void DeleteVehiculoById(string placa);
    }
}
