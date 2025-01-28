using Domain.Interface.RepositoryInterface;
using Domain.Interface.ServiceInterface;
using Domain.Request;
using Domain.Response;
using Infra.Repository;
using Model;
namespace Core.Service
{
    public class ProfessionalService : IProfessionalService
    {
        private readonly IProfessionalRepository _professionalRepository;
        public ProfessionalService(IProfessionalRepository professionalRepository)
        {
            _professionalRepository = professionalRepository;
        }
        public Task<IEnumerable<ProfessionalResponse>> CheckProfessionals()
        {
            return _professionalRepository.CheckProfessionals();
        }
        public async Task CreateProfessionals(CreateProfessionalsRequest createProfessionals)
        {
            Professionals professionals = new Professionals(createProfessionals);
            await _professionalRepository.CreateProfessionals(professionals);
        }
        public async Task AlterProfessionals(AlterProfessionalsRequest alterProfessional)
        {
            var professionals = await _professionalRepository.GetByIdAsync(alterProfessional.Id);
            if (professionals == null)
                throw new ArgumentException("Id Not Found");
            professionals.Update(alterProfessional);
            await _professionalRepository.AlterProfessionals(professionals);
        }
        public async Task DeleteProfessionals(int id)
        {
            var professionals = await _professionalRepository.GetByIdAsync(id);
            if (professionals == null)
                throw new ArgumentException("Id Not Found");
            await _professionalRepository.DeleteProfessionals(professionals);
        }
    }
}