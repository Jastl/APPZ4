using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClub.DAL.Entities;

namespace FitnessClub.BLL.Interfaces
{
    public interface IReservationService
    {
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetClientReservationsAsync(int clientId);
        Task<IEnumerable<Reservation>> GetScheduleReservationsAsync(int scheduleId);
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(int id);
        Task<bool> CanMakeReservationAsync(int clientId, int scheduleId);
        Task ConfirmReservationAsync(int reservationId);
    }
} 