using AspNetCoreHero.Results;
using MediatR;
using SampleBackEndTemplate.Application.Extensions;
using SampleBackEndTemplate.Application.Interfaces.Repositories.GymManagement;
using SampleBackEndTemplate.Domain.Entities.GymManagement;
using SIDCMMS.Application.Features.GymManagement.Queries.GetAllPaged;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SampleBackEndTemplate.Application.Features.Membership.Applicants.Queries.GetAllMembers
{
    public class GetAllMembersQuery : IRequest<PaginatedResult<GetAllMembersResponse>>
    {
        public string SearchKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllMembersQuery(string searchKey, int pageNumber, int pageSize)
        {
            SearchKey = searchKey;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, PaginatedResult<GetAllMembersResponse>>
    {
        private IMembersRepository _membersRepository;

        public GetAllMembersQueryHandler(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }
        public async Task<PaginatedResult<GetAllMembersResponse>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Members, GetAllMembersResponse>> expression = e => new GetAllMembersResponse
            {
                Id = e.Id,
                FullName = e.FirstName + " " + e.MiddleName + " " + e.LastName + " " + e.SuffixName,
                Name = e.FirstName + " " + e.LastName + " " + e.SuffixName,
                PhoneNumber = e.PhoneNumber,
                Gender = e.Gender,
                Address = e.Barangay + "," + e.City + "," + e.Province + " " + e.ZipCode  
            };

            if (string.IsNullOrWhiteSpace(request.SearchKey))
            {

                var membersList = await _membersRepository.Members.Select(expression)
                    .OrderByDescending(x => x.Id)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return membersList;
            }
            else
            {
                var membersList = await _membersRepository.Members.Select(expression)
              .Where(x => (x.Name.Replace(" ", "").ToLower().Trim().Contains(request.SearchKey.Replace(" ", "").ToLower().Trim())
                           || x.FullName.Replace(" ", "").ToLower().Trim().Contains(request.SearchKey.Replace(" ", "").ToLower().Trim())))
              .OrderByDescending(x => x.Id)
              .ToPaginatedListAsync(request.PageNumber, request.PageSize);

                return membersList;
            }
        }
    }
}
