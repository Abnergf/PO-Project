using Domain.Response;
using Model;
namespace Domain.Interface.RepositoryInterface
{
    public interface IProfessionalRepository
    {
        Task<IEnumerable<ProfessionalResponse>> CheckProfessionals();
        Task CreateProfessionals(Professionals professionals);
        Task AlterProfessionals(Professionals professionals);
        Task<Professionals?> GetByIdAsync(int id);
        Task DeleteProfessionals(Professionals professionals);

    }
}