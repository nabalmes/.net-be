using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using SampleBackEndTemplate.Application.Interfaces.Repositories;
using SampleBackEndTemplate.Application.Interfaces.Repositories.GymManagement;
using SampleBackEndTemplate.Domain.Entities.GymManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace SampleBackEndTemplate.Application.Features.GymManagement.Commands.Update
{
    public class UpdateMemberCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SuffixName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ZipCode { get; set; }
    }

    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Result<int>>
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public UpdateMemberCommandHandler(IMembersRepository membersRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _membersRepository = membersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            //Members details = new Members();
            var member = await _membersRepository.GetById(request.Id);
            member = _mapper.Map(request, member);

            //for check if okay to remove, redundant mapping
            //details = _mapper.Map<Employment>(employment);
            //await _employmentRepository.UpdateAsync(details);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(member.Id);
        }
    }
}