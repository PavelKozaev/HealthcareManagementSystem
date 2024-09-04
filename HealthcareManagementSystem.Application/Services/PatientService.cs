using AutoMapper;
using HealthcareManagementSystem.Application.DTOs;
using HealthcareManagementSystem.Application.Services.Interfaces;
using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.Interfaces;

namespace HealthcareManagementSystem.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> GetPatientsAsync(int pageNumber, int pageSize, string sortBy)
        {
            var patients = await _patientRepository.GetPatientsWithDetailsAsync(pageNumber, pageSize, sortBy);
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }

        public async Task<PatientForEditDto> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            return _mapper.Map<PatientForEditDto>(patient);
        }

        public async Task AddPatientAsync(PatientForEditDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _patientRepository.AddAsync(patient);
        }

        public async Task UpdatePatientAsync(PatientForEditDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _patientRepository.UpdateAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }
    }
}
