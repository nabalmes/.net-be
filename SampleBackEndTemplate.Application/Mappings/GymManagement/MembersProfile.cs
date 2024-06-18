using AutoMapper;
using SampleBackEndTemplate.Application.Features.GymManagement.Commands.Create;
using SampleBackEndTemplate.Application.Features.GymManagement.Commands.Update;
using SampleBackEndTemplate.Application.Features.GymManagement.Queries.GetById;
using SampleBackEndTemplate.Domain.Entities.GymManagement;
using SIDCMMS.Application.Features.GymManagement.Queries.GetAllPaged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBackEndTemplate.Application.Mappings.GymManagement
{
    public class MembersProfile : Profile
    {
        public MembersProfile()
        {
            CreateMap<CreateMemberCommand, Members>().ReverseMap();
            CreateMap<UpdateMemberCommand, Members>().ReverseMap();
            CreateMap<GetAllMembersResponse, Members>().ReverseMap();
            CreateMap<GetMembersByIdResponse, Members>().ReverseMap();
        }
    }
}