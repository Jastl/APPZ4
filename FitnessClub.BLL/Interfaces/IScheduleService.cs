using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClub.DAL.Entities;

namespace FitnessClub.BLL.Interfaces
{
    public interface IScheduleService
    {
        Task<Schedule> GetScheduleByIdAsync(int id);
        Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
        Task<IEnumerable<Schedule>> GetClubSchedulesAsync(int clubId);
        Task<IEnumerable<Schedule>> GetSchedulesByDateRangeAsync(int clubId, DateTime startDate, DateTime endDate);
        Task<Schedule> CreateScheduleAsync(Schedule schedule);
        Task UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(int id);
        Task<bool> IsScheduleAvailableAsync(int scheduleId);
        Task<int> GetAvailableSpotsAsync(int scheduleId);
    }
} 