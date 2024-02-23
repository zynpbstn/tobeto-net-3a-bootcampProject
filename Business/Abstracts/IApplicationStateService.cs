using Business.Requests.Applications;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;


namespace Business.Abstracts
{
    public interface IApplicationStateService
    {
        Task<CreateApplicationStateResponse> AddAsync(CreateApplicationStateRequest request);
        Task<UpdateApplicationStateResponse> UpdateAsync(UpdateApplicationStateRequest request);
        Task<DeleteApplicationStateResponse> DeleteAsync(DeleteApplicationStateRequest request);
        Task<GetByIdApplicationStateResponse> GetById(GetByIdApplicationStateRequest request);
        Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync();
    }
}
