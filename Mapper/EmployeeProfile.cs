using AutoMapper;
using Route.NetDAL.Entities;
using Route.NetPL.Models;

namespace Route.NetPL.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
