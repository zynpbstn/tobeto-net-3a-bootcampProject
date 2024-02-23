using Business.Requests.Applicants;
using Business.Responses.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicantService
    {
        public AddApplicantResponse Add(AddApplicantRequest request);
        public UpdateApplicantResponse Update(UpdateApplicantRequest request);
        public DeleteApplicantResponse Delete(DeleteApplicantRequest request);
        public List<GetAllApplicantResponse> GetAll();
        public GetApplicantByIdResponse GetById(GetApplicantByIdRequest request);

    }
}
