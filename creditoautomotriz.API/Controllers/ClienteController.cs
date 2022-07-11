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
    public class ClienteController : ControllerBase
    {
        private ICliente servicio;

        public ClienteController(ICliente _servicio)
        {

            servicio = _servicio;

        }

        [HttpGet]
        [Route("all")]
        public async Task<List<Cliente>> GetClientes()
        {
            return await servicio.GetClientes();
        }
        [HttpGet]
        public async Task<Cliente> GetCliente(string identificacion)
        {
            return await servicio.GetClienteById(identificacion);
        }
        [HttpPost]
        public void PostCliente([FromBody] Cliente nuevoCliente)
        {
            servicio.PostCliente(nuevoCliente);
        }
        [HttpPut]
        public void EditCliente([FromBody] Cliente cliente)
        {
            servicio.EditCliente(cliente);
        }
        [HttpDelete]
        [Route("{identificacion}")]
        public void DeleteCliente(string identificacion)
        {
            servicio.DeleteClienteById(identificacion);
        }
    }
}
