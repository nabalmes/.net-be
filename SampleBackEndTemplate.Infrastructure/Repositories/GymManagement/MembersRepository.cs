using Microsoft.EntityFrameworkCore;
using SampleBackEndTemplate.Domain.Entities.GymManagement;
using SampleBackEndTemplate.Application.Interfaces.Repositories.GymManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleBackEndTemplate.Application.Interfaces.Repositories;

namespace SampleBackEndTemplate.Infrastructure.Repositories.GymManagement
{
    public class MembersRepository : IMembersRepository
    {
        private readonly IRepositoryAsync<Members> _repository;

        public MembersRepository(IRepositoryAsync<Members> repository)
        {
            _repository = repository;
        }

        public IQueryable<Members> Members => _repository.Entities;

        public async Task<int> InsertAsync(Members members)
        {
            await _repository.AddAsync(members);
            return members.Id;
        }
        public async Task<List<Members>> GetAllMembers()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateAsync(Members members)
        {
            await _repository.UpdateAsync(members);
        }

        
        public async Task<Members> GetById(int memberId)
        {
            return await _repository.Entities
                .Where(p => p.Id == memberId)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteByIdAsync(int memberId)
        {
            var member = await _repository.Entities.Where(p => p.Id == memberId).FirstOrDefaultAsync();
            await _repository.DeleteAsync(member);

        }
        /**
        public async Task<Members> GetLastMember()
        {
            return await _repository.Entities.Where(o => o.ApplicantNumber.StartsWith(DateTime.UtcNow.Year.ToString())).OrderByDescending(i => i.ApplicantNumber).FirstOrDefaultAsync();
        }

        public async Task<string> AssignMemberCodeAsync()
        {
            var recentApplicant = await _repository.Entities.Where(o => o.ApplicantNumber.StartsWith(DateTime.UtcNow.Year.ToString())).OrderByDescending(i => i.ApplicantNumber).FirstOrDefaultAsync();
            int maxCode = 000000;
            if (recentApplicant != null)
                maxCode = Convert.ToInt32(recentApplicant.ApplicantNumber.Remove(0, 4));

            maxCode++;
            return string.Format("{0}{1}", DateTime.UtcNow.Year.ToString(), maxCode.ToString().PadLeft(6, '0'));
        }
        **/
    }
}