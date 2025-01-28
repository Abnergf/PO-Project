using Domain.Interface.RepositoryInterface;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.MainDbContext;
namespace Infra.Repository
{
    public class FieldOfOperationRepository : IFieldOfOperationRepository
    {
        public readonly MainDbContext _context;
        public FieldOfOperationRepository(MainDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FieldOfOperationsResponse>> CheckFieldOfOperation()
        {
            var fieldOfOperations = await _context.FieldOfOperation
               .Include(p => p.Professionals)
               .Select(p => new FieldOfOperationsResponse
               {
                   Id = p.Id,
                   Title = p.Title,
                   Code = p.Code,
                   Description = p.Description,
                   CreationDate = p.CreationDate,
               })
               .ToListAsync();
            return fieldOfOperations;
        }
        public async Task CreateFieldOfOperation(FieldOfOperation fieldOfOperation)
        {
            _context.FieldOfOperation.Add(fieldOfOperation);
            await _context.SaveChangesAsync();
        }
        public async Task AlterFieldOfOperation(FieldOfOperation fieldOfOperation)
        {
            _context.FieldOfOperation.Update(fieldOfOperation);
            await _context.SaveChangesAsync();
        }
        public async Task<FieldOfOperation?> GetByIdAsync(int id)
        {
            return await _context.FieldOfOperation.FindAsync(id);
        }
        public async Task DeleteFieldOfOperation(int id)
        {
            var fieldOfOperation = await _context.FieldOfOperation.FindAsync(id);
            _context.FieldOfOperation.Remove(fieldOfOperation);
            await _context.SaveChangesAsync();
        }
    }
}