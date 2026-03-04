using AutoMapper;
using WorkForceManagementService.Entities;
using WorkForceManagementService.ModelDTOs;

namespace WorkForceManagementService.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
        }
    }
}
