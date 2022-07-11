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
    public class PatioController : ControllerBase
    {
        private IPatio servicio;

        public PatioController(IPatio _servicio)
        {

            servicio = _servicio;

        }
        [HttpGet]
        [Route("all")]
        public async Task<List<Patio>> GetPatios()
        {
            return await servicio.GetPatios();
        }
        [HttpGet]
        public async Task<Patio> GetPatio(int puntoVenta)
        {
            return await servicio.GetPatioById(puntoVenta);
        }
        [HttpPost]
        public void AddPatio([FromBody] Patio nuevoPatio)
        {
            servicio.AddPatio(nuevoPatio);
        }
        [HttpPut]
        public void EditPatio([FromBody] Patio patio)
        {
            servicio.EditPatio(patio);
        }
        [HttpDelete]
        //[Route("{puntoVenta}")]
        public void DeletePatio(int puntoVenta)
        {
            servicio.DeletePatioById(puntoVenta);
        }
    }
}
