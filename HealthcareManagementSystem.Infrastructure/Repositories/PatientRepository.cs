using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.Interfaces;
using HealthcareManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManagementSystem.Infrastructure.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HealthcareDbContext context) : base(context) { }

        public async Task<IEnumerable<Patient>> GetPatientsWithDetailsAsync(int pageNumber, int pageSize, string sortBy)
        {
            var query = _context.Patients
                .Include(p => p.Plot)
                .AsQueryable();

            query = sortBy switch
            {
                "LastName" => query.OrderBy(p => p.LastName),
                "FirstName" => query.OrderBy(p => p.FirstName),
                "DateOfBirth" => query.OrderBy(p => p.DateOfBirth),
                _ => query.OrderBy(p => p.Id)
            };

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
