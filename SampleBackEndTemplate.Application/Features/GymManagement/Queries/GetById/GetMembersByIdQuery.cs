using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SampleBackEndTemplate.Application.Features.GymManagement.Queries.GetById;
using SampleBackEndTemplate.Application.Interfaces.Repositories.GymManagement;
using SampleBackEndTemplate.Domain.Entities.GymManagement;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SIDCMMS.Application.Features.GymManagement.Queries.GetById
{
    public class GetMembersByIdQuery : IRequest<Result<GetMembersByIdResponse>>
    {
        public int Id { get; set; }

        public GetMembersByIdQuery(int id)
        {
            Id = id;

        }

        public class GetMembersByIdQueryHandler : IRequestHandler<GetMembersByIdQuery, Result<GetMembersByIdResponse>>
        {
            private IMembersRepository _membersRepository;
            private IMapper _mapper;

            public GetMembersByIdQueryHandler(IMapper mapper, IMembersRepository membersRepository)
            {
                _membersRepository = membersRepository;
                _mapper = mapper;
            }
            public async Task<Result<GetMembersByIdResponse>> Handle(GetMembersByIdQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<Members, GetMembersByIdResponse>> expression = e => new GetMembersByIdResponse
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    SuffixName = e.SuffixName,
                    Age = e.Age,
                    Gender = e.Gender,
                    Birthdate = e.Birthdate,
                    PhoneNumber = e.PhoneNumber,
                    Barangay = e.Barangay,
                    City = e.City,
                    Province = e.Province,
                    ZipCode = e.ZipCode,
                    EmailAddress = e.EmailAddress
                };
                var members = await _membersRepository.Members
               .Select(expression)
               .Where(x => x.Id == request.Id)
               .FirstOrDefaultAsync();

                var mappedMembers = _mapper.Map<GetMembersByIdResponse>(members);
                return Result<GetMembersByIdResponse>.Success(mappedMembers);

            }
        }
    }
}