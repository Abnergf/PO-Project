using Domain.Request;
using Domain.Response;
namespace Domain.Interface.ServiceInterface
{
    public interface IProfessionalService
    {
        Task<IEnumerable<ProfessionalResponse>> CheckProfessionals();
        Task CreateProfessionals(CreateProfessionalsRequest createProfessionals);
        Task AlterProfessionals(AlterProfessionalsRequest alterProfessionalRequest);
        Task DeleteProfessionals(int id);
    }
}