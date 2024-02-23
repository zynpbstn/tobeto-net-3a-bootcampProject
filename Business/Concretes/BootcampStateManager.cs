using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
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
    public class BootcampStateManager : IBootcampStateService
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly IMapper _mapper;

        public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
        {
            _bootcampStateRepository = bootcampStateRepository;
            _mapper = mapper;
        }

        public async Task<CreateBootcampStateResponse> AddAsync(CreateBootcampStateRequest request)
        {
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            await _bootcampStateRepository.AddAsync(bootcampState);

            CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
            return response;
        }

        public Task<DeleteBootcampStateResponse> DeleteAsync(DeleteBootcampStateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdBootcampStateResponse> GetById(GetByIdBootcampStateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateBootcampStateResponse> UpdateAsync(UpdateBootcampStateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
