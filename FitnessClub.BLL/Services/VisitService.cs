using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;
using FitnessClub.DAL.Interfaces;

namespace FitnessClub.BLL.Services
{
    public class VisitService : IVisitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMembershipService _membershipService;

        public VisitService(IUnitOfWork unitOfWork, IMembershipService membershipService)
        {
            _unitOfWork = unitOfWork;
            _membershipService = membershipService;
        }

        public async Task<Visit> GetVisitByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Visit>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<Visit>> GetClientVisitsAsync(int clientId)
        {
            return await _unitOfWork.GetRepository<Visit>()
                .FindAsync(v => v.ClientId == clientId);
        }

        public async Task<IEnumerable<Visit>> GetAllVisitsAsync()
        {
            return await _unitOfWork.GetRepository<Visit>().GetAllAsync();
        }

        public async Task<Visit> CreateVisitAsync(Visit visit)
        {
            if (visit == null)
                throw new ArgumentNullException(nameof(visit));

            await _unitOfWork.GetRepository<Visit>().AddAsync(visit);
            await _unitOfWork.SaveChangesAsync();
            return visit;
        }

        public async Task<Visit> RegisterVisitAsync(Visit visit)
        {
            if (visit == null)
                throw new ArgumentNullException(nameof(visit));

            // If using membership, validate it
            if (!visit.IsSingleVisit && visit.MembershipId.HasValue)
            {
                if (!await _membershipService.CanVisitClubAsync(visit.MembershipId.Value, visit.ClubId))
                    throw new InvalidOperationException("Cannot visit this club with the provided membership");
            }

            visit.VisitTime = DateTime.Now;
            return await CreateVisitAsync(visit);
        }

        public async Task<Visit> CreateSingleVisitAsync(int clientId, int clubId, decimal price)
        {
            var visit = new Visit
            {
                ClientId = clientId,
                ClubId = clubId,
                VisitTime = DateTime.Now,
                IsSingleVisit = true,
                SingleVisitPrice = price
            };

            return await CreateVisitAsync(visit);
        }

        public async Task<Visit> CreateMembershipVisitAsync(int clientId, int clubId, int membershipId)
        {
            if (!await _membershipService.CanVisitClubAsync(membershipId, clubId))
                throw new InvalidOperationException("Cannot visit this club with the provided membership");

            var visit = new Visit
            {
                ClientId = clientId,
                ClubId = clubId,
                MembershipId = membershipId,
                VisitTime = DateTime.Now,
                IsSingleVisit = false
            };

            return await CreateVisitAsync(visit);
        }

        public async Task UpdateVisitAsync(Visit visit)
        {
            if (visit == null)
                throw new ArgumentNullException(nameof(visit));

            _unitOfWork.GetRepository<Visit>().Update(visit);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteVisitAsync(int id)
        {
            var visit = await GetVisitByIdAsync(id);
            if (visit == null)
                throw new ArgumentException($"Visit with ID {id} not found");

            _unitOfWork.GetRepository<Visit>().Remove(visit);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 