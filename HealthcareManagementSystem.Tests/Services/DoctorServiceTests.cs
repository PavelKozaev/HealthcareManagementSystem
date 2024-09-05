using AutoMapper;
using HealthcareManagementSystem.Application.DTOs;
using HealthcareManagementSystem.Application.Mappings;
using HealthcareManagementSystem.Application.Services;
using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.Interfaces;
using Moq;

namespace HealthcareManagementSystem.Tests.Services
{
    public class DoctorServiceTests
    {
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;
        private readonly IMapper _mapper;
        private readonly DoctorService _doctorService;

        public DoctorServiceTests()
        {
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
            _doctorService = new DoctorService(_doctorRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task GetDoctorsAsync_ReturnsListOfDoctors()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor { Id = 1, FullName = "John Doe", Office = new Office { Number = "101" }, Specialization = new Specialization { Name = "Cardiology" }, Plot = new Plot { Number = "A1" }},
                new Doctor { Id = 2, FullName = "Jane Smith", Office = new Office { Number = "102" }, Specialization = new Specialization { Name = "Neurology" }, Plot = new Plot { Number = "B1" }}
            };
            var doctorDtos = new List<DoctorDto>
            {
                new DoctorDto { Id = 1, FullName = "John Doe", OfficeNumber = "101", SpecializationName = "Cardiology", PlotNumber = "A1" },
                new DoctorDto { Id = 2, FullName = "Jane Smith", OfficeNumber = "102", SpecializationName = "Neurology", PlotNumber = "B1" }
            };
            _doctorRepositoryMock.Setup(repo => repo.GetDoctorsWithDetailsAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                                .ReturnsAsync(doctors);

            // Act
            var result = await _doctorService.GetDoctorsAsync(1, 10, "FullName");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(doctorDtos[0].FullName, result.First().FullName);
        }

        [Fact]
        public async Task GetDoctorByIdAsync_ReturnsDoctorForEditDto()
        {
            // Arrange
            var doctor = new Doctor { Id = 1, FullName = "John Doe", Office = new Office { Number = "101" }, Specialization = new Specialization { Name = "Cardiology" }, Plot = new Plot { Number = "A1" } };
            var doctorForEditDto = new DoctorForEditDto { Id = 1, FullName = "John Doe", OfficeId = 1, SpecializationId = 1, PlotId = 1 };
            _doctorRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                                .ReturnsAsync(doctor);

            // Act
            var result = await _doctorService.GetDoctorByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(doctorForEditDto.Id, result.Id);
            Assert.Equal(doctorForEditDto.FullName, result.FullName);
        }

        [Fact]
        public async Task AddDoctorAsync_AddsDoctorAndReturnsDto()
        {
            // Arrange
            var doctorForCreateDto = new DoctorForCreateDto { FullName = "John Doe", OfficeId = 1, SpecializationId = 1, PlotId = 1 };
            var doctor = new Doctor { Id = 1, FullName = "John Doe", OfficeId = 1, SpecializationId = 1, PlotId = 1 };
            var doctorDto = new DoctorDto { Id = 1, FullName = "John Doe", OfficeNumber = "101", SpecializationName = "Cardiology", PlotNumber = "A1" };
            _doctorRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Doctor>()))
                                .Returns(Task.CompletedTask);
            _doctorRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                                .ReturnsAsync(doctor);

            // Act
            var result = await _doctorService.AddDoctorAsync(doctorForCreateDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(doctorDto.FullName, result.FullName);
        }

        [Fact]
        public async Task UpdateDoctorAsync_UpdatesDoctor()
        {
            // Arrange
            var doctorForEditDto = new DoctorForEditDto { Id = 1, FullName = "John Doe", OfficeId = 1, SpecializationId = 1, PlotId = 1 };
            var doctor = new Doctor { Id = 1, FullName = "John Doe", OfficeId = 1, SpecializationId = 1, PlotId = 1 };
            _doctorRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Doctor>()))
                                .Returns(Task.CompletedTask);

            // Act
            await _doctorService.UpdateDoctorAsync(doctorForEditDto);

            // Assert
            _doctorRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Doctor>()), Times.Once);
        }

        [Fact]
        public async Task DeleteDoctorAsync_DeletesDoctor()
        {
            // Arrange
            var doctorId = 1;
            _doctorRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<int>()))
                                .Returns(Task.CompletedTask);

            // Act
            await _doctorService.DeleteDoctorAsync(doctorId);

            // Assert
            _doctorRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
