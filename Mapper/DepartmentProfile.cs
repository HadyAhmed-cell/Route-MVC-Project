using AutoMapper;
using Route.NetDAL.Entities;
using Route.NetPL.Models;

namespace Route.NetPL.Mapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
        }
    }
}
