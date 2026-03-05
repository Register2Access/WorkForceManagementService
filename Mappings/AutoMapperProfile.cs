using AutoMapper;
using WorkForceManagementService.Entities;
using WorkForceManagementService.ModelDTOs;

namespace WorkForceManagementService.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterRequest, User>()
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .ForMember(dest => dest.Department, opt => opt.Ignore());

            CreateMap<User, RegisterRequest>();
        }
    }
}
