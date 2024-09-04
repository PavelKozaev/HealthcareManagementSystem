using HealthcareManagementSystem.Core.Entities;

namespace HealthcareManagementSystem.Core.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsWithDetailsAsync(int pageNumber, int pageSize, string sortBy);
    }
}
