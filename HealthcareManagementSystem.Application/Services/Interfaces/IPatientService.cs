﻿using HealthcareManagementSystem.Application.DTOs;

namespace HealthcareManagementSystem.Application.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetPatientsAsync(int pageNumber, int pageSize, string sortBy);
        Task<PatientForEditDto> GetPatientByIdAsync(int id);
        Task<PatientDto> AddPatientAsync(PatientForCreateDto patientDto);
        Task UpdatePatientAsync(PatientForEditDto patientDto);
        Task DeletePatientAsync(int id);
    }
}
