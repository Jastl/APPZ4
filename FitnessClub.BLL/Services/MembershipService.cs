using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;
using FitnessClub.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FitnessClub.BLL.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MembershipService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _unitOfWork.GetRepository<Client>().GetAllAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Client>().GetByIdAsync(id);
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            await _unitOfWork.GetRepository<Client>().AddAsync(client);
            await _unitOfWork.SaveChangesAsync();
            return client;
        }

        public async Task UpdateClientAsync(Client client)
        {
            _unitOfWork.GetRepository<Client>().Update(client);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await GetClientByIdAsync(id);
            if (client != null)
            {
                _unitOfWork.GetRepository<Client>().Remove(client);
                await _unitOfWork.SaveChangesAsync();
            }
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
            await _unitOfWork.GetRepository<Club>().AddAsync(club);
            await _unitOfWork.SaveChangesAsync();
            return club;
        }

        public async Task UpdateClubAsync(Club club)
        {
            _unitOfWork.GetRepository<Club>().Update(club);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteClubAsync(int id)
        {
            var club = await GetClubByIdAsync(id);
            if (club != null)
            {
                _unitOfWork.GetRepository<Club>().Remove(club);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Membership>> GetAllMembershipsAsync()
        {
            var memberships = await _unitOfWork.GetRepository<Membership>().GetAllAsync();
            await LoadMembershipRelations(memberships);
            return memberships;
        }

        public async Task<Membership> GetMembershipByIdAsync(int id)
        {
            var membership = await _unitOfWork.GetRepository<Membership>().GetByIdAsync(id);
            if (membership != null)
            {
                await LoadMembershipRelations(new[] { membership });
            }
            return membership;
        }

        public async Task<IEnumerable<Membership>> GetClientMembershipsAsync(int clientId)
        {
            var memberships = await _unitOfWork.GetRepository<Membership>().GetAllAsync();
            var clientMemberships = memberships.Where(m => m.ClientId == clientId);
            await LoadMembershipRelations(clientMemberships);
            return clientMemberships;
        }

        public async Task<Membership> CreateMembershipAsync(Membership membership)
        {
            membership.EndDate = membership.StartDate.AddDays(membership.DurationInDays);
            await _unitOfWork.GetRepository<Membership>().AddAsync(membership);
            await _unitOfWork.SaveChangesAsync();
            return membership;
        }

        public async Task UpdateMembershipAsync(Membership membership)
        {
            membership.EndDate = membership.StartDate.AddDays(membership.DurationInDays);
            _unitOfWork.GetRepository<Membership>().Update(membership);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMembershipAsync(int id)
        {
            var membership = await GetMembershipByIdAsync(id);
            if (membership != null)
            {
                _unitOfWork.GetRepository<Membership>().Remove(membership);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private async Task LoadMembershipRelations(IEnumerable<Membership> memberships)
        {
            var clientIds = memberships.Select(m => m.ClientId).Distinct();
            var clubIds = memberships.Select(m => m.ClubId).Distinct();

            var clients = await _unitOfWork.GetRepository<Client>().GetAllAsync();
            var clubs = await _unitOfWork.GetRepository<Club>().GetAllAsync();

            foreach (var membership in memberships)
            {
                membership.Client = clients.FirstOrDefault(c => c.Id == membership.ClientId);
                membership.Club = clubs.FirstOrDefault(c => c.Id == membership.ClubId);
            }
        }

        public async Task<bool> IsMembershipValidAsync(int membershipId)
        {
            var membership = await GetMembershipByIdAsync(membershipId);
            if (membership == null)
                return false;

            return membership.EndDate >= DateTime.Now;
        }

        public async Task<bool> CanVisitClubAsync(int membershipId, int clubId)
        {
            var membership = await GetMembershipByIdAsync(membershipId);
            if (membership == null || !await IsMembershipValidAsync(membershipId))
                return false;

            // Network membership can visit any club
            if (membership.ClubId == null)
                return true;

            // Regular membership can only visit assigned club
            return membership.ClubId == clubId;
        }
    }
} 