using HealthcareManagementSystem.Core.Entities;

namespace HealthcareManagementSystem.Core.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetPatientsWithDetailsAsync(int pageNumber, int pageSize, string sortBy);
    }
}
