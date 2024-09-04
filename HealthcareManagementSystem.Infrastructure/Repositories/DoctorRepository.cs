using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.Interfaces;
using HealthcareManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManagementSystem.Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HealthcareDbContext context) : base(context) { }

        public async Task<IEnumerable<Doctor>> GetDoctorsWithDetailsAsync(int pageNumber, int pageSize, string sortBy)
        {
            var query = _context.Doctors
                .Include(d => d.Office)
                .Include(d => d.Specialization)
                .Include(d => d.Plot)
                .AsQueryable();

            query = sortBy switch
            {
                "FullName" => query.OrderBy(d => d.FullName),
                "Office" => query.OrderBy(d => d.Office.Number),
                "Specialization" => query.OrderBy(d => d.Specialization.Name),
                _ => query.OrderBy(d => d.Id)
            };

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
