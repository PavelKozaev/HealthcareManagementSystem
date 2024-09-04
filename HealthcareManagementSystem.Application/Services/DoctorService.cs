using AutoMapper;
using HealthcareManagementSystem.Application.DTOs;
using HealthcareManagementSystem.Application.Services.Interfaces;
using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.Interfaces;

namespace HealthcareManagementSystem.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync(int pageNumber, int pageSize, string sortBy)
        {
            var doctors = await _doctorRepository.GetDoctorsWithDetailsAsync(pageNumber, pageSize, sortBy);
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }

        public async Task<DoctorForEditDto> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            return _mapper.Map<DoctorForEditDto>(doctor);
        }

        public async Task<DoctorDto> AddDoctorAsync(DoctorForCreateDto doctorDto) 
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.AddAsync(doctor);
            return _mapper.Map<DoctorDto>(doctor); 
        }

        public async Task UpdateDoctorAsync(DoctorForEditDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }
    }
}
