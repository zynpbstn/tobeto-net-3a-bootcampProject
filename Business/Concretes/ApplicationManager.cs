using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<CreateApplicationResponse> AddAsync(CreateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            await _applicationRepository.AddAsync(application);

            CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
            return response;
        }

        public Task<DeleteApplicationResponse> DeleteAsync(DeleteApplicationRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            List<Application> applications = await _applicationRepository.GetAllAsync(include: x => x.Include(x => x.Bootcamp.Name).Include(x => x.Applicant.UserName));
            List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
            return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, "Listed Successfully");
        }

        public Task<GetByIdApplicationResponse> GetById(GetByIdApplicationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateApplicationResponse> UpdateAsync(UpdateApplicationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
