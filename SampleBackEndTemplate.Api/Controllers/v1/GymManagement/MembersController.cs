using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleBackEndTemplate.API.Controllers;
using SampleBackEndTemplate.Application.Features.GymManagement.Commands.Create;
using SampleBackEndTemplate.Application.Features.GymManagement.Commands.Update;
using SampleBackEndTemplate.Application.Features.Membership.Applicants.Queries.GetAllMembers;
using SIDCMMS.Application.Features.GymManagement.Commands.Delete;
using SIDCMMS.Application.Features.GymManagement.Queries.GetById;
using System.Threading.Tasks;

namespace SampleBackEndTemplate.Api.Controllers.v1.GymManagement
{
    public class MembersController : BaseApiController<MembersController>
    {

        [HttpPost("create-member")]
        [AllowAnonymous]

        public async Task<IActionResult> PostMembers(CreateMemberCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("update-member")]
        [AllowAnonymous]

        public async Task<IActionResult> UpdateMembers(UpdateMemberCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("members-list")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMembers(string searchKey, int pageNumber, int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllMembersQuery(searchKey, pageNumber, pageSize)));
        }

        [HttpGet("members-by-id")]
        [AllowAnonymous]

        public async Task<IActionResult> GetMembersById(int id)
        {
            return Ok(await _mediator.Send(new GetMembersByIdQuery(id)));
        }

        [HttpDelete("delete-by-id")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteById(int id)
        {
            return Ok(await _mediator.Send(new DeleteMemberCommand(id)));
        }
    }
}