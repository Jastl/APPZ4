using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClub.DAL.Entities;

namespace FitnessClub.BLL.Interfaces
{
    public interface IVisitService
    {
        Task<Visit> GetVisitByIdAsync(int id);
        Task<IEnumerable<Visit>> GetClientVisitsAsync(int clientId);
        Task<IEnumerable<Visit>> GetAllVisitsAsync();
        Task<Visit> CreateVisitAsync(Visit visit);
        Task<Visit> CreateSingleVisitAsync(int clientId, int clubId, decimal price);
        Task<Visit> CreateMembershipVisitAsync(int clientId, int clubId, int membershipId);
        Task<Visit> RegisterVisitAsync(Visit visit);
        Task UpdateVisitAsync(Visit visit);
        Task DeleteVisitAsync(int id);
    }
} 