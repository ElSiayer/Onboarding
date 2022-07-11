using creditoautomotriz.Domain.Interfaces;
using creditoautomotriz.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creditoautomotriz.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AsignacioClientePatioController : ControllerBase
    {
        //private object servicio;

        private IClientePatio servicio;

        public AsignacioClientePatioController(IClientePatio _servicio)
        {

            servicio = _servicio;

        }

        
        [HttpGet]
        public async Task<ClientePatio> GetClientePatioByIds(string identificacion, int puntoVenta)
        {
            return await servicio.GetClientePatioByIds(identificacion, puntoVenta);
        }
        [HttpGet]
        [Route("ByCliente")]
        public async Task<List<ClientePatio>> GetClientePatioByClienteId(string identificacionCliente)
        {
            return await servicio.GetClientePatioByClienteId(identificacionCliente);
        }
        [HttpGet]
        [Route("ByPatio")]
        public async Task<List<ClientePatio>> GetClientePatioByPatioId(int puntoVenta)
        {
            return await servicio.GetClientePatioByPatioId(puntoVenta);
        }
        [HttpPost]
        public void AddClientePatio([FromBody] ClientePatio nuevoClientePatio)
        {
            servicio.AddClientePatio(nuevoClientePatio);
        }
        [HttpPut]
        public void EditCliente([FromBody] ClientePatio clientePatio)
        {
            servicio.EditClientePatio(clientePatio);
        }
        [HttpDelete]
        //[Route("delete")]
        public void DeleteCliente(string identificacion, int puntoVenta)
        {
            servicio.DeleteClientePatioByIds(identificacion,puntoVenta);
        }


    }
}
