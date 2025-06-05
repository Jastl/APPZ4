using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;
using FitnessClub.DAL.Interfaces;

namespace FitnessClub.BLL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMembershipService _membershipService;

        public ReservationService(IUnitOfWork unitOfWork, IMembershipService membershipService)
        {
            _unitOfWork = unitOfWork;
            _membershipService = membershipService;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Reservation>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<Reservation>> GetClientReservationsAsync(int clientId)
        {
            return await _unitOfWork.GetRepository<Reservation>()
                .FindAsync(r => r.ClientId == clientId);
        }

        public async Task<IEnumerable<Reservation>> GetScheduleReservationsAsync(int scheduleId)
        {
            return await _unitOfWork.GetRepository<Reservation>()
                .FindAsync(r => r.ScheduleId == scheduleId);
        }

        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            if (!await CanMakeReservationAsync(reservation.ClientId, reservation.ScheduleId))
                throw new InvalidOperationException("Cannot make reservation for this schedule");

            reservation.ReservationTime = DateTime.Now;
            reservation.IsConfirmed = false;

            await _unitOfWork.GetRepository<Reservation>().AddAsync(reservation);
            await _unitOfWork.SaveChangesAsync();
            return reservation;
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            _unitOfWork.GetRepository<Reservation>().Update(reservation);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await GetReservationByIdAsync(id);
            if (reservation == null)
                throw new ArgumentException($"Reservation with ID {id} not found");

            _unitOfWork.GetRepository<Reservation>().Remove(reservation);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> CanMakeReservationAsync(int clientId, int scheduleId)
        {
            var schedule = await _unitOfWork.GetRepository<Schedule>().GetByIdAsync(scheduleId);
            if (schedule == null)
                return false;

            // Check if schedule is not full
            var reservations = await GetScheduleReservationsAsync(scheduleId);
            if (reservations.Count() >= schedule.MaxParticipants)
                return false;

            // Check if client has valid membership for the club
            var memberships = await _unitOfWork.GetRepository<Membership>()
                .FindAsync(m => m.ClientId == clientId && 
                              (m.ClubId == schedule.ClubId || m.ClubId == null) && 
                              m.EndDate >= DateTime.Now);

            return memberships.Any();
        }

        public async Task ConfirmReservationAsync(int reservationId)
        {
            var reservation = await GetReservationByIdAsync(reservationId);
            if (reservation == null)
                throw new ArgumentException($"Reservation with ID {reservationId} not found");

            reservation.IsConfirmed = true;
            await UpdateReservationAsync(reservation);
        }
    }
} 