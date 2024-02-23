
using Azure;
using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
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
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantManager(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public AddApplicantResponse Add(AddApplicantRequest request)
        {
            Applicant applicant = new Applicant();
            applicant.UserName = request.UserName;
            applicant.About = request.About;
            applicant.FirstName = request.FirstName;
            applicant.LastName = request.LastName;
            applicant.DateOfBirth = request.DateOfBirth;
            applicant.Email = request.Email;
            applicant.NationalIdentity = request.NationalIdentity;
            applicant.Password = request.Password;

            _applicantRepository.Add(applicant);

            AddApplicantResponse response = new AddApplicantResponse();
            response.UserName = applicant.UserName;
            response.CreatedDate = applicant.CreatedDate;
            response.About = applicant.About;
            response.FirstName = applicant.FirstName;
            response.LastName = applicant.LastName;
            response.DateOfBirth = applicant.DateOfBirth;
            response.Email = applicant.Email;
            response.NationalIdentity = applicant.NationalIdentity;
            response.Password = applicant.Password;
            return response;
        }

        public DeleteApplicantResponse Delete(DeleteApplicantRequest request)
        {
            Applicant deleteToApplicant = _applicantRepository.GetById(predicate: applicant => applicant.Id == request.Id);

            if (deleteToApplicant != null)
            {
                var deletedApplicant = _applicantRepository.Delete(deleteToApplicant);

                var response = new DeleteApplicantResponse {DeletedDate = deletedApplicant.DeletedDate,UserName =deletedApplicant.UserName,Id=deletedApplicant.Id};

                return response;
            }
            else
            {
                throw new Exception("Applicant not found");
            }

        }

        public List<GetAllApplicantResponse> GetAll()
        {
            List<GetAllApplicantResponse> applicants = new List<GetAllApplicantResponse>();

            foreach(var applicant in _applicantRepository.GetAll())
            {
                GetAllApplicantResponse response = new GetAllApplicantResponse();
                response.Id = applicant.Id;
                response.UserName = applicant.UserName;
                response.About = applicant.About;
                response.FirstName = applicant.FirstName;
                response.LastName = applicant.LastName;
                response.DateOfBirth = applicant.DateOfBirth;
                response.Email = applicant.Email;
                response.NationalIdentity = applicant.NationalIdentity;
                response.Password = applicant.Password;

                applicants.Add(response);

            }

            return applicants;
        }

        public GetApplicantByIdResponse GetById(GetApplicantByIdRequest request)
        {
            Applicant applicant = _applicantRepository.GetById(predicate: applicant => applicant.Id == request.Id);

            if (applicant != null)
            {
                GetApplicantByIdResponse response = new GetApplicantByIdResponse();
                response.UserName = applicant.UserName;
                response.About = applicant.About;
                response.FirstName = applicant.FirstName;
                response.LastName = applicant.LastName;
                response.DateOfBirth = applicant.DateOfBirth;
                response.Email = applicant.Email;
                response.NationalIdentity = applicant.NationalIdentity;
                response.Password = applicant.Password;
                return response;
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }

        public UpdateApplicantResponse Update(UpdateApplicantRequest request)
        {
            Applicant updateToApplicant = _applicantRepository.GetById(predicate: applicant => applicant.Id == request.Id);

            if (updateToApplicant != null)
            {

                updateToApplicant.Id = request.Id;
                updateToApplicant.UserName = request.UserName;
                updateToApplicant.About = request.About;
                updateToApplicant.FirstName = request.FirstName;
                updateToApplicant.LastName = request.LastName;
                updateToApplicant.DateOfBirth = request.DateOfBirth;
                updateToApplicant.Email = request.Email;
                updateToApplicant.NationalIdentity = request.NationalIdentity;
                updateToApplicant.Password = request.Password;

                _applicantRepository.Update(updateToApplicant);

                var updatedApplicant = new UpdateApplicantResponse();
                updatedApplicant.Email = request.Email;
                updatedApplicant.Id = request.Id;
                updatedApplicant.UserName = request.UserName;
                updatedApplicant.About = request.About;
                updatedApplicant.FirstName = request.FirstName;
                updatedApplicant.LastName = request.LastName;
                updatedApplicant.DateOfBirth = request.DateOfBirth;
                updatedApplicant.NationalIdentity = request.NationalIdentity;
                updatedApplicant.Password = request.Password;
                updatedApplicant.UpdatedDate = updateToApplicant.UpdatedDate;

                return updatedApplicant;
            }
            else
            {
                // Handle applicant not found error
                throw new Exception("Applicant not found");
            }
        }
    }
}
