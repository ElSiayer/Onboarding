using creditoautomotriz.Domain.Interfaces;
using creditoautomotriz.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditoautomotriz.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private IVehiculo servicio;

        public VehiculoController(IVehiculo _servicio)
        {

            servicio = _servicio;

        }
        [HttpGet]
        [Route("all")]
        public async Task<List<Vehiculo>> GetVehiculos()
        {
            return await servicio.GetVehiculos();
        }
        [HttpGet]
        [Route("allByModel")]
        public async Task<List<Vehiculo>> GetVehiculosByModel(string modelo)
        {
            return await servicio.GetVehiculosByModelo(modelo);
        }
        [HttpGet]
        [Route("allByMarca")]
        public async Task<List<Vehiculo>> GetVehiculosByMarca(int marcaId)
        {
            return await servicio.GetVehiculosByMarca(marcaId);
        }
        [HttpGet]
        public async Task<Vehiculo> GetVehiculoByPlaca(string placa)
        {
            return await servicio.GetVehiculoByPlaca(placa);
        }
        [HttpPost]
        public void AddVehiculo([FromBody] Vehiculo nuevoVehiculo)
        {
            servicio.AddVehiculo(nuevoVehiculo);
        }
        [HttpPut]
        public void EditVehiculo([FromBody] Vehiculo vehiculo)
        {
            servicio.EditVehiculo(vehiculo);
        }
        [HttpDelete]
        //[Route("{puntoVenta}")]
        public void DeleteVehiculo(string placa)
        {
            servicio.DeleteVehiculoById(placa);
        }
    }
}
