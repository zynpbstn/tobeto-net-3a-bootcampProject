using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Applications;
using Business.Responses.Bootcamps;
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
    public class BootcampManager : IBootcampService
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;

        public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
        }

        public async Task<CreateBootcampResponse> AddAsync(CreateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            await _bootcampRepository.AddAsync(bootcamp);

            CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
            return response;
        }

        public Task<DeleteBootcampResponse> DeleteAsync(DeleteBootcampRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdBootcampResponse> GetById(GetByIdBootcampRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateBootcampResponse> UpdateAsync(UpdateBootcampRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
