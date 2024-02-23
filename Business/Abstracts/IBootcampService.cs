using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;


namespace Business.Abstracts
{
    public interface IBootcampService
    {
        Task<CreateBootcampResponse> AddAsync(CreateBootcampRequest request);
        Task<UpdateBootcampResponse> UpdateAsync(UpdateBootcampRequest request);
        Task<DeleteBootcampResponse> DeleteAsync(DeleteBootcampRequest request);
        Task<GetByIdBootcampResponse> GetById(GetByIdBootcampRequest request);
        Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync();
    }
}
