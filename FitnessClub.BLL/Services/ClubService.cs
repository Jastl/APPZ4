using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;
using FitnessClub.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.BLL.Services
{
    public class ClubService : IClubService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClubService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Club>> GetAllClubsAsync()
        {
            return await _unitOfWork.GetRepository<Club>().GetAllAsync();
        }

        public async Task<Club> GetClubByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Club>().GetByIdAsync(id);
        }

        public async Task<Club> CreateClubAsync(Club club)
        {
            if (club == null)
                throw new ArgumentNullException(nameof(club));

            await _unitOfWork.GetRepository<Club>().AddAsync(club);
            await _unitOfWork.SaveChangesAsync();
            return club;
        }

        public async Task UpdateClubAsync(Club club)
        {
            if (club == null)
                throw new ArgumentNullException(nameof(club));

            _unitOfWork.GetRepository<Club>().Update(club);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteClubAsync(int id)
        {
            var club = await GetClubByIdAsync(id);
            if (club == null)
                throw new ArgumentException($"Club with ID {id} not found");

            _unitOfWork.GetRepository<Club>().Remove(club);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Schedule>> GetClubScheduleAsync(int clubId)
        {
            var schedules = await _unitOfWork.GetRepository<Schedule>()
                .FindAsync(s => s.ClubId == clubId);
            return schedules;
        }

        public async Task<bool> IsClubAvailableForVisitAsync(int clubId, int clientId)
        {
            var client = await _unitOfWork.GetRepository<Client>().GetByIdAsync(clientId);
            if (client == null)
                return false;

            // Check if client has a valid membership for this club
            var memberships = await _unitOfWork.GetRepository<Membership>()
                .FindAsync(m => m.ClientId == clientId && 
                              (m.ClubId == clubId || m.ClubId == null) && // null ClubId means network membership
                              m.EndDate >= DateTime.Now);

            return memberships.Any();
        }
    }
} 