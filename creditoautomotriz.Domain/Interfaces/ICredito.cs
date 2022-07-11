using creditoautomotriz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface ICredito
    {
        Task<List<Credito>> GetCreditos();
        Task<Credito> GetCreditoByCreditoId(int creditoId);
        void AddCredito(Credito nuevoCredito);
    }
}
