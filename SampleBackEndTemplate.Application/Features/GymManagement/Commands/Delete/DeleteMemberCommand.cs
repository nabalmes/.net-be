using AspNetCoreHero.Results;
using MediatR;
using SampleBackEndTemplate.Application.Interfaces.Repositories;
using SampleBackEndTemplate.Application.Interfaces.Repositories.GymManagement;
using System.Threading;
using System.Threading.Tasks;

namespace SIDCMMS.Application.Features.GymManagement.Commands.Delete
{
    public class DeleteMemberCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }

        public DeleteMemberCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Result<bool>>
    {
        private IUnitOfWork _unitOfWork;
        private IMembersRepository _membersRepository;

        public DeleteMemberCommandHandler(IUnitOfWork unitOfWork, IMembersRepository membersRepository)
        {
            _unitOfWork = unitOfWork;
            _membersRepository = membersRepository;

        }
        public async Task<Result<bool>> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            await _membersRepository.DeleteByIdAsync(request.Id);
            await _unitOfWork.Commit(cancellationToken);
            return Result<bool>.Success();
        }
    }
}
