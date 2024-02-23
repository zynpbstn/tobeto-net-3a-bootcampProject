using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Applicants;
using Business.Responses.Employees;
using Business.Responses.Instructors;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorManager(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public CreateInstructorResponse Add(CreateInstructorRequest request)
        {
            Instructor instructor = new Instructor();
            instructor.UserName = request.UserName;
            instructor.CompanyName = request.CompanyName;
            instructor.FirstName = request.FirstName;
            instructor.LastName = request.LastName;
            instructor.DateOfBirth = request.DateOfBirth;
            instructor.Email = request.Email;
            instructor.NationalIdentity = request.NationalIdentity;
            instructor.Password = request.Password;

            _instructorRepository.Add(instructor);

            CreateInstructorResponse response = new CreateInstructorResponse();
            response.UserName = instructor.UserName;
            response.CreatedDate = instructor.CreatedDate;
            response.CompanyName = instructor.CompanyName;
            response.FirstName = instructor.FirstName;
            response.LastName = instructor.LastName;
            response.DateOfBirth = instructor.DateOfBirth;
            response.Email = instructor.Email;
            response.NationalIdentity = instructor.NationalIdentity;
            response.Password = instructor.Password;
            return response;
        }

        public DeleteInstructorResponse Delete(DeleteInstructorRequest request)
        {
            Instructor deleteToInstructor = _instructorRepository.GetById(predicate: instructor => instructor.Id == request.Id);

            if (deleteToInstructor != null)
            {
                var deletedInstructor = _instructorRepository.Delete(deleteToInstructor);

                var response = new DeleteInstructorResponse { DeletedTime = deletedInstructor.DeletedDate, UserName = deletedInstructor.UserName, Id = deletedInstructor.Id };

                return response;
            }
            else
            {
                throw new Exception("Instructor not found");
            }
        }

        public List<GetAllInstructorResponse> GetAll()
        {
            List<GetAllInstructorResponse> instructors = new List<GetAllInstructorResponse>();

            foreach (var instructor in _instructorRepository.GetAll())
            {
                GetAllInstructorResponse response = new GetAllInstructorResponse();
                response.Id = instructor.Id;
                response.UserName = instructor.UserName;
                response.CompanyName = instructor.CompanyName;
                response.FirstName = instructor.FirstName;
                response.LastName = instructor.LastName;
                response.DateOfBirth = instructor.DateOfBirth;
                response.Email = instructor.Email;
                response.NationalIdentity = instructor.NationalIdentity;
                response.Password = instructor.Password;

                instructors.Add(response);

            }

            return instructors;
        }

        public GetInstructorByIdResponse GetById(GetInstructorByIdRequest request)
        {
            Instructor instructor = _instructorRepository.GetById(predicate: instructor => instructor.Id == request.Id);

            if (instructor != null)
            {
                GetInstructorByIdResponse response = new GetInstructorByIdResponse();
                response.UserName = instructor.UserName;
                response.CompanyName = instructor.CompanyName;
                response.FirstName = instructor.FirstName;
                response.LastName = instructor.LastName;
                response.DateOfBirth = instructor.DateOfBirth;
                response.Email = instructor.Email;
                response.NationalIdentity = instructor.NationalIdentity;
                response.Password = instructor.Password;
                return response;
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }

        public UpdateInstructorResponse Update(UpdateInstructorRequest request)
        {
            Instructor updateToInstructor = _instructorRepository.GetById(predicate: instructor => instructor.Id == request.Id);

            if (updateToInstructor != null)
            {

                updateToInstructor.Id = request.Id;
                updateToInstructor.UserName = request.UserName;
                updateToInstructor.CompanyName = request.CompanyName;
                updateToInstructor.FirstName = request.FirstName;
                updateToInstructor.LastName = request.LastName;
                updateToInstructor.DateOfBirth = request.DateOfBirth;
                updateToInstructor.Email = request.Email;
                updateToInstructor.NationalIdentity = request.NationalIdentity;
                updateToInstructor.Password = request.Password;

                _instructorRepository.Update(updateToInstructor);

                var updatedInstructor = new UpdateInstructorResponse();
                updatedInstructor.Email = request.Email;
                updatedInstructor.Id = request.Id;
                updatedInstructor.UserName = request.UserName;
                updatedInstructor.CompanyName = request.CompanyName;
                updatedInstructor.FirstName = request.FirstName;
                updatedInstructor.LastName = request.LastName;
                updatedInstructor.DateOfBirth = request.DateOfBirth;
                updatedInstructor.NationalIdentity = request.NationalIdentity;
                updatedInstructor.Password = request.Password;
                updatedInstructor.UpdatedDate = updateToInstructor.UpdatedDate;

                return updatedInstructor;
            }
            else
            {
                // Handle Instructor not found error
                throw new Exception("Instructor not found");
            }
        }
    }
}
