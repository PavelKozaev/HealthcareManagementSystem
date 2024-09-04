using HealthcareManagementSystem.Application.DTOs;

namespace HealthcareManagementSystem.Application.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetDoctorsAsync(int pageNumber, int pageSize, string sortBy);
        Task<DoctorForEditDto> GetDoctorByIdAsync(int id);
        Task AddDoctorAsync(DoctorForEditDto doctorDto);
        Task UpdateDoctorAsync(DoctorForEditDto doctorDto);
        Task DeleteDoctorAsync(int id);
    }
}
