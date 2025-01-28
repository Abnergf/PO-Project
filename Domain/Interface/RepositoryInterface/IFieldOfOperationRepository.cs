using Domain.Response;
using Model;
namespace Domain.Interface.RepositoryInterface
{
    public interface IFieldOfOperationRepository
    {
        Task<IEnumerable<FieldOfOperationsResponse>> CheckFieldOfOperation();
        Task CreateFieldOfOperation(FieldOfOperation fieldOfOperation);
        Task AlterFieldOfOperation(FieldOfOperation fieldOfOperation);
        Task<FieldOfOperation?> GetByIdAsync(int id);
        Task DeleteFieldOfOperation(int id);
    }
}