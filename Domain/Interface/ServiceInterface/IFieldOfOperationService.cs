using Domain.Request;
using Domain.Response;
namespace Domain.Interface.ServiceInterface
{
    public interface IFieldOfOperationService
    {
        Task<IEnumerable<FieldOfOperationsResponse>> CheckFieldOfOperation();
        Task CreateFieldOfOperation(CreateFieldOfOperationRequest createFieldOfOperation);
        Task AlterFieldOfOperation(AlterFieldOfOperationRequest alterFieldOfOperation);
        Task DeleteFieldOfOperation(int id);
    }
}