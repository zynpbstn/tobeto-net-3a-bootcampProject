using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicationService
    {
        Task<CreateApplicationResponse> AddAsync(CreateApplicationRequest request);
        Task<UpdateApplicationResponse> UpdateAsync(UpdateApplicationRequest request);
        Task<DeleteApplicationResponse> DeleteAsync(DeleteApplicationRequest request);
        Task<GetByIdApplicationResponse> GetById(GetByIdApplicationRequest request);
        Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync();
    }
}
