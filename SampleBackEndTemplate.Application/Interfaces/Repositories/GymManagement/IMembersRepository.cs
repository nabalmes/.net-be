using SampleBackEndTemplate.Domain.Entities.GymManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBackEndTemplate.Application.Interfaces.Repositories.GymManagement
{
    public interface IMembersRepository
    {
        Task<int> InsertAsync(Members members);

        IQueryable<Members> Members { get; }

        Task<List<Members>> GetAllMembers();        

        Task<Members> GetById(int memberId);
        /**
        Task<Members> GetLastMember();
        **/
        //Task<string> AssignMemberCodeAsync();
        

        Task UpdateAsync(Members members);
        Task DeleteByIdAsync(int memberId);

    }
}