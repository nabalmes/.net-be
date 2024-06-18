using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using SampleBackEndTemplate.Application.Interfaces;
using SampleBackEndTemplate.Application.DTOs.Identity;
using SampleBackEndTemplate.Application.Interfaces.Repositories;
using SampleBackEndTemplate.Domain.Entities.GymManagement;
using System.Linq;
using SampleBackEndTemplate.Application.Interfaces.Repositories.GymManagement;

namespace SampleBackEndTemplate.Application.Features.GymManagement.Commands.Create
{
    public class CreateMemberCommand : IRequest<Result<int>>
    {
        #region Command Properties

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SuffixName { get; set; }
        public string Province {  get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ZipCode { get; set; }

        #endregion Command Properties
    }

    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Result<int>>
    {
        #region Variables

        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }
        private IIdentityService _iIdentityService { get; set; }

        private readonly IMembersRepository _membersRepository;

        #endregion Variables

        #region Constructor

        public CreateMemberCommandHandler(IMembersRepository membersRepository
                                           , IMapper mapper
                                           , IUnitOfWork unitOfWork
                                           , IIdentityService iIdentityService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _iIdentityService = iIdentityService;
            _membersRepository = membersRepository;
        }

        #endregion Constructor

        #region Public

        public async Task<Result<int>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = _mapper.Map<Members>(request);
            // = await AssignApplicantNumberAsync();

            /**
            var applicantRegisterRequest = _mapper.Map<RegisterRequest>(request);
            applicantRegisterRequest.UserName = applicant.ApplicantNumber;
            if (string.IsNullOrWhiteSpace(applicantRegisterRequest.Email))
                applicantRegisterRequest.Email = string.Format("{0}.member@sidc.coop", applicantRegisterRequest.UserName);
            await _iIdentityService.RegisterApplicantAsync(applicantRegisterRequest);

            applicant.ApplicantStatusId = 1;
            applicant.IsOnlineApplication = true;

            if (string.IsNullOrWhiteSpace(applicant.EmailAddress))
                applicant.EmailAddress = null;

            if (string.IsNullOrWhiteSpace(applicant.ContactNumber))
                applicant.ContactNumber = null;
            **/

            await _membersRepository.InsertAsync(member);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(member.Id);
        }

        #endregion Public
        /**
        #region Private

        private async Task<string> AssignApplicantNumberAsync()
        {
            var recentApplicant = await _applicantRepository.GetLastApplicant();
            int maxCode = 000000;
            if (recentApplicant != null)
                maxCode = Convert.ToInt32(recentApplicant.ApplicantNumber.Remove(0, 4));

            maxCode++;
            return string.Format("{0}{1}", DateTime.UtcNow.Year.ToString(), maxCode.ToString().PadLeft(6, '0'));
        }

        #endregion Private
        **/
    }
}