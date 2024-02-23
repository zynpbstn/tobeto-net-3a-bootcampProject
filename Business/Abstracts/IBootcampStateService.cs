using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;


namespace Business.Abstracts
{
    public interface IBootcampStateService
    {
        Task<CreateBootcampStateResponse> AddAsync(CreateBootcampStateRequest request);
        Task<UpdateBootcampStateResponse> UpdateAsync(UpdateBootcampStateRequest request);
        Task<DeleteBootcampStateResponse> DeleteAsync(DeleteBootcampStateRequest request);
        Task<GetByIdBootcampStateResponse> GetById(GetByIdBootcampStateRequest request);
        Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync();
    }
}
