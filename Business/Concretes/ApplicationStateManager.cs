using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicationStateManager : IApplicationStateService
    {
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly IMapper _mapper;

        public ApplicationStateManager(IApplicationStateRepository applicationstateRepository, IMapper mapper)
        {
            _applicationStateRepository = applicationstateRepository;
            _mapper = mapper;
        }

        public async Task<CreateApplicationStateResponse> AddAsync(CreateApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _applicationStateRepository.AddAsync(applicationState);

            CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
            return response;
        }

        public Task<DeleteApplicationStateResponse> DeleteAsync(DeleteApplicationStateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            List<ApplicationState> applicationStates = await _applicationStateRepository.GetAllAsync(include: x => x.Include(x => x.Application).Include(x => x.Application.Bootcamp));
            List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationStates);
            return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses, "Listed Successfully");
        }

        public Task<GetByIdApplicationStateResponse> GetById(GetByIdApplicationStateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateApplicationStateResponse> UpdateAsync(UpdateApplicationStateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
