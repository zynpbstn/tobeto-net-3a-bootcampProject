using Business.Requests.Employees;
using Business.Responses.Employees;
using Entities.Concretes;
using AutoMapper;


namespace Business.Profiles.Employee
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, CreateEmployeeResponse>().ReverseMap();

            CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeResponse>().ReverseMap();

            CreateMap<Employee, GetEmployeeByIdResponse>().ReverseMap();
            CreateMap<Employee, GetAllEmployeeResponse>().ReverseMap();
        }

        
    }
}
