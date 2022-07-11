using creditoautomotriz.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IPatio
    {
        Task<Patio> GetPatioById(int patioId);
        Task<List<Patio>> GetPatios();
        void AddPatio(Patio nuevoClientePatio);
        void EditPatio(Patio clientePatio);
        void DeletePatioById(int patioId);
    }
}
