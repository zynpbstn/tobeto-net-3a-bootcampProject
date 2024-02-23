using Business.Abstracts;
using Business.Requests.Employees;
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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public CreateEmployeeResponse Add(CreateEmployeeRequest request)
        {
            Employee employee = new Employee();
            employee.UserName = request.UserName;
            employee.Position = request.Position;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.DateOfBirth = request.DateOfBirth;
            employee.Email = request.Email;
            employee.NationalIdentity = request.NationalIdentity;
            employee.Password = request.Password;

            _employeeRepository.Add(employee);

            CreateEmployeeResponse response = new CreateEmployeeResponse();
            response.UserName = employee.UserName;
            response.CreatedDate = employee.CreatedDate;
            response.Position = employee.Position;
            response.FirstName = employee.FirstName;
            response.LastName = employee.LastName;
            response.DateOfBirth = employee.DateOfBirth;
            response.Email = employee.Email;
            response.NationalIdentity = employee.NationalIdentity;
            response.Password = employee.Password;
            return response;
        }

        public DeleteEmployeeResponse Delete(DeleteEmployeeRequest request)
        {
            Employee deleteToEmployee = _employeeRepository.GetById(predicate: employee => employee.Id == request.Id);

            if (deleteToEmployee != null)
            {
                var deletedEmployee = _employeeRepository.Delete(deleteToEmployee);

                var response = new DeleteEmployeeResponse { DeletedTime = deletedEmployee.DeletedDate, UserName = deletedEmployee.UserName, Id = deletedEmployee.Id };

                return response;
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }

        public List<GetAllEmployeeResponse> GetAll()
        {
            List<GetAllEmployeeResponse> employees = new List<GetAllEmployeeResponse>();

            foreach (var employee in _employeeRepository.GetAll())
            {
                GetAllEmployeeResponse response = new GetAllEmployeeResponse();
                response.Id = employee.Id;
                response.UserName = employee.UserName;
                response.Position = employee.Position;
                response.FirstName = employee.FirstName;
                response.LastName = employee.LastName;
                response.DateOfBirth = employee.DateOfBirth;
                response.Email = employee.Email;
                response.NationalIdentity = employee.NationalIdentity;
                response.Password = employee.Password;

                employees.Add(response);

            }

            return employees;
        }

        public GetEmployeeByIdResponse GetById(GetEmployeeByIdRequest request)
        {
            Employee employee = _employeeRepository.GetById(predicate: employee => employee.Id == request.Id);

            if (employee != null)
            {
                GetEmployeeByIdResponse response = new GetEmployeeByIdResponse();
                response.UserName = employee.UserName;
                response.Position = employee.Position;
                response.FirstName = employee.FirstName;
                response.LastName = employee.LastName;
                response.DateOfBirth = employee.DateOfBirth;
                response.Email = employee.Email;
                response.NationalIdentity = employee.NationalIdentity;
                response.Password = employee.Password;
                return response;
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }

        public UpdateEmployeeResponse Update(UpdateEmployeeRequest request)
        {
            Employee updateToEmployee = _employeeRepository.GetById(predicate: employee => employee.Id == request.Id);

            if (updateToEmployee != null)
            {

                updateToEmployee.Id = request.Id;
                updateToEmployee.UserName = request.UserName;
                updateToEmployee.Position = request.Position;
                updateToEmployee.FirstName = request.FirstName;
                updateToEmployee.LastName = request.LastName;
                updateToEmployee.DateOfBirth = request.DateOfBirth;
                updateToEmployee.Email = request.Email;
                updateToEmployee.NationalIdentity = request.NationalIdentity;
                updateToEmployee.Password = request.Password;

                _employeeRepository.Update(updateToEmployee);

                var updatedEmployee = new UpdateEmployeeResponse();
                updatedEmployee.Email = request.Email;
                updatedEmployee.Id = request.Id;
                updatedEmployee.UserName = request.UserName;
                updatedEmployee.Position = request.Position;
                updatedEmployee.FirstName = request.FirstName;
                updatedEmployee.LastName = request.LastName;
                updatedEmployee.DateOfBirth = request.DateOfBirth;
                updatedEmployee.NationalIdentity = request.NationalIdentity;
                updatedEmployee.Password = request.Password;
                updatedEmployee.UpdatedDate = updateToEmployee.UpdatedDate;

                return updatedEmployee;
            }
            else
            {
                // Handle Employee not found error
                throw new Exception("Employee not found");
            }
        }
    }
}
