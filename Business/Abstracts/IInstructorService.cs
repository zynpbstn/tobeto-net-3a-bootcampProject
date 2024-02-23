using Business.Requests.Instructors;
using Business.Responses.Instructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        public CreateInstructorResponse Add(CreateInstructorRequest request);
        public UpdateInstructorResponse Update(UpdateInstructorRequest request);
        public DeleteInstructorResponse Delete(DeleteInstructorRequest request);
        public List<GetAllInstructorResponse> GetAll();
        public GetInstructorByIdResponse GetById(GetInstructorByIdRequest request);
    }
}
