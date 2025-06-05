using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClub.DAL.Entities;

namespace FitnessClub.BLL.Interfaces
{
    public interface IClubService
    {
        Task<IEnumerable<Club>> GetAllClubsAsync();
        Task<Club> GetClubByIdAsync(int id);
        Task<Club> CreateClubAsync(Club club);
        Task UpdateClubAsync(Club club);
        Task DeleteClubAsync(int id);
        Task<IEnumerable<Schedule>> GetClubScheduleAsync(int clubId);
        Task<bool> IsClubAvailableForVisitAsync(int clubId, int clientId);
    }
} 