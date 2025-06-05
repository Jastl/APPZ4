using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClub.DAL.Entities;

namespace FitnessClub.BLL.Interfaces
{
    public interface IMembershipService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> CreateClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int id);

        Task<IEnumerable<Club>> GetAllClubsAsync();
        Task<Club> GetClubByIdAsync(int id);
        Task<Club> CreateClubAsync(Club club);
        Task UpdateClubAsync(Club club);
        Task DeleteClubAsync(int id);

        Task<IEnumerable<Membership>> GetAllMembershipsAsync();
        Task<Membership> GetMembershipByIdAsync(int id);
        Task<IEnumerable<Membership>> GetClientMembershipsAsync(int clientId);
        Task<Membership> CreateMembershipAsync(Membership membership);
        Task UpdateMembershipAsync(Membership membership);
        Task DeleteMembershipAsync(int id);
        Task<bool> IsMembershipValidAsync(int membershipId);
        Task<bool> CanVisitClubAsync(int membershipId, int clubId);
    }
} 