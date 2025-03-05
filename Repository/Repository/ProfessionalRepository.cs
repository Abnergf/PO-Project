using Domain.Interface.RepositoryInterface;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.MainDbContext;
namespace Infra.Repository
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly MainDbContext _context;
        public ProfessionalRepository(MainDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProfessionalResponse>> CheckProfessionals()
        {
            var professionals = await _context.Professionals
                .Include(p => p.FieldOfOperation)
                .Select(p => new ProfessionalResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    FieldOfOperationCode = p.FieldOfOperation.Code,
                    FieldOfOperationName = p.FieldOfOperation.Title,
                    CreationDate = p.CreationDate,
                    Active = p.Active
                })
                .ToListAsync();
            return professionals;
        }
        public async Task CreateProfessionals(Professionals professionals)
        {
            _context.Professionals.Add(professionals);
            await _context.SaveChangesAsync();
        }
        public async Task AlterProfessionals(Professionals professionals)
        {
            _context.Professionals.Update(professionals);
            await _context.SaveChangesAsync();
        }
        public async Task<Professionals?> GetByIdAsync(int id)
        {
            return await _context.Professionals.FindAsync(id);
        }
        public async Task DeleteProfessionals(Professionals professionals)
        {
            var projectTasks = await _context.ProjectTasks
                .Where(pt => pt.ProfessionalId == professionals.Id)
                .ToListAsync();
            foreach (var task in projectTasks)
            {
                var taskFiles = await _context.TaskFiles
                    .Where(tf => tf.ProjectTaskId == task.Id)
                    .ToListAsync();
                foreach (var file in taskFiles)
                {
                    _context.TaskFiles.Remove(file);
                }
                _context.ProjectTasks.Remove(task);
            }
            _context.Professionals.Remove(professionals);
            await _context.SaveChangesAsync();
        }
    }
}