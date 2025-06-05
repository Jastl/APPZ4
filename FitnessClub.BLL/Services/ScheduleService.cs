using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;
using FitnessClub.DAL.Interfaces;

namespace FitnessClub.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationService _reservationService;

        public ScheduleService(IUnitOfWork unitOfWork, IReservationService reservationService)
        {
            _unitOfWork = unitOfWork;
            _reservationService = reservationService;
        }

        public async Task<Schedule> GetScheduleByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Schedule>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _unitOfWork.GetRepository<Schedule>().GetAllAsync();
        }

        public async Task<IEnumerable<Schedule>> GetClubSchedulesAsync(int clubId)
        {
            return await _unitOfWork.GetRepository<Schedule>()
                .FindAsync(s => s.ClubId == clubId);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByDateRangeAsync(int clubId, DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.GetRepository<Schedule>()
                .FindAsync(s => s.ClubId == clubId && 
                               s.StartTime >= startDate && 
                               s.EndTime <= endDate);
        }

        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException(nameof(schedule));

            if (schedule.StartTime >= schedule.EndTime)
                throw new ArgumentException("End time must be after start time");

            if (schedule.MaxParticipants <= 0)
                throw new ArgumentException("Maximum participants must be greater than 0");

            await _unitOfWork.GetRepository<Schedule>().AddAsync(schedule);
            await _unitOfWork.SaveChangesAsync();
            return schedule;
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException(nameof(schedule));

            if (schedule.StartTime >= schedule.EndTime)
                throw new ArgumentException("End time must be after start time");

            if (schedule.MaxParticipants <= 0)
                throw new ArgumentException("Maximum participants must be greater than 0");

            var reservations = await _reservationService.GetScheduleReservationsAsync(schedule.Id);
            if (reservations.Count() > schedule.MaxParticipants)
                throw new InvalidOperationException("Cannot reduce maximum participants below current reservation count");

            _unitOfWork.GetRepository<Schedule>().Update(schedule);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteScheduleAsync(int id)
        {
            var schedule = await GetScheduleByIdAsync(id);
            if (schedule == null)
                throw new ArgumentException($"Schedule with ID {id} not found");

            var reservations = await _reservationService.GetScheduleReservationsAsync(id);
            if (reservations.Any())
                throw new InvalidOperationException("Cannot delete schedule with existing reservations");

            _unitOfWork.GetRepository<Schedule>().Remove(schedule);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> IsScheduleAvailableAsync(int scheduleId)
        {
            var schedule = await GetScheduleByIdAsync(scheduleId);
            if (schedule == null)
                return false;

            if (schedule.StartTime <= DateTime.Now)
                return false;

            var availableSpots = await GetAvailableSpotsAsync(scheduleId);
            return availableSpots > 0;
        }

        public async Task<int> GetAvailableSpotsAsync(int scheduleId)
        {
            var schedule = await GetScheduleByIdAsync(scheduleId);
            if (schedule == null)
                throw new ArgumentException($"Schedule with ID {scheduleId} not found");

            var reservations = await _reservationService.GetScheduleReservationsAsync(scheduleId);
            return schedule.MaxParticipants - reservations.Count();
        }
    }
} 