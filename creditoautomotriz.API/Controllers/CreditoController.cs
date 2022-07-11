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
    public class CreditoController : ControllerBase
    {
        private ICredito servicio;

        public CreditoController(ICredito _servicio)
        {

            servicio = _servicio;

        }
        

        [HttpGet]
        [Route("all")]
        public async Task<List<Credito>> GetCreditos()
        {
            return await servicio.GetCreditos();
        }

        [HttpGet]
        public async Task<Credito> GetCreditoById(int idCredito)
        {
            return await servicio.GetCreditoByCreditoId(idCredito);
        }

        [HttpPost]
        public void AddCredito([FromBody] Credito nuevoCredito)
        {
            servicio.AddCredito(nuevoCredito);
        }


    }
}
