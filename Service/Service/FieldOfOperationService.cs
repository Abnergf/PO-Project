using Domain.Interface.RepositoryInterface;
using Domain.Interface.ServiceInterface;
using Domain.Request;
using Domain.Response;
using Model;
namespace Core.Service
{
    public class FieldOfOperationService : IFieldOfOperationService
    {
        public readonly IFieldOfOperationRepository _fieldOfOperationRepository;
        public FieldOfOperationService(IFieldOfOperationRepository fieldOfOperationRepository)
        {
            _fieldOfOperationRepository = fieldOfOperationRepository;
        }
        public async Task<IEnumerable<FieldOfOperationsResponse>> CheckFieldOfOperation()
        {
            return await _fieldOfOperationRepository.CheckFieldOfOperation();
        }
        public async Task CreateFieldOfOperation(CreateFieldOfOperationRequest createFieldOfOperation)
        {
            FieldOfOperation fieldOfOperation = new FieldOfOperation(createFieldOfOperation);

            await _fieldOfOperationRepository.CreateFieldOfOperation(fieldOfOperation);
        }
        public async Task AlterFieldOfOperation(AlterFieldOfOperationRequest alterFieldOfOperation)
        {
            var fieldOfOperation = await _fieldOfOperationRepository.GetByIdAsync(alterFieldOfOperation.Id);
            fieldOfOperation.Update(alterFieldOfOperation);
            if (fieldOfOperation == null)
                throw new ArgumentException("Id Not Found");
            await _fieldOfOperationRepository.AlterFieldOfOperation(fieldOfOperation);
        }
        public async Task DeleteFieldOfOperation(int id)
        {
            var fieldOfOperation = await _fieldOfOperationRepository.GetByIdAsync(id);
            if (fieldOfOperation == null)
                throw new ArgumentException("Id Not Found");
            await _fieldOfOperationRepository.DeleteFieldOfOperation(id);
        }
    }
}