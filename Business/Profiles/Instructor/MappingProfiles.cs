using AutoMapper;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Entities.Concretes;


namespace Business.Profiles.Instructor
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, CreateInstructorResponse>().ReverseMap();

            CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorResponse>().ReverseMap();

            CreateMap<Instructor, GetInstructorByIdResponse>().ReverseMap();
            CreateMap<Instructor, GetAllInstructorResponse>().ReverseMap();
        }

    }
}
