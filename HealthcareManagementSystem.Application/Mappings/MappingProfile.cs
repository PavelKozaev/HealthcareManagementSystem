using AutoMapper;
using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Application.DTOs;

namespace HealthcareManagementSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            CreateMap<Doctor, DoctorDto>()
                .ForMember(dest => dest.OfficeNumber, opt => opt.MapFrom(src => src.Office.Number))
                .ForMember(dest => dest.SpecializationName, opt => opt.MapFrom(src => src.Specialization.Name))
                .ForMember(dest => dest.PlotNumber, opt => opt.MapFrom(src => src.Plot.Number));

            CreateMap<Doctor, DoctorForEditDto>().ReverseMap();
            CreateMap<Doctor, DoctorForCreateDto>().ReverseMap();

            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.PlotNumber, opt => opt.MapFrom(src => src.Plot.Number));

            CreateMap<Patient, PatientForEditDto>().ReverseMap();
            CreateMap<Patient, PatientForCreateDto>().ReverseMap();
        }
    }
}
