using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Responses.Applicants;
using Business.Responses.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEmployeeService
    {
        public CreateEmployeeResponse Add(CreateEmployeeRequest request);
        public UpdateEmployeeResponse Update(UpdateEmployeeRequest request);
        public DeleteEmployeeResponse Delete(DeleteEmployeeRequest request);
        public List<GetAllEmployeeResponse> GetAll();
        public GetEmployeeByIdResponse GetById(GetEmployeeByIdRequest request);
    }
}
