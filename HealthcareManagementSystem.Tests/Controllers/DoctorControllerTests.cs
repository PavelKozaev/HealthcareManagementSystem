using HealthcareManagementSystem.API.Controllers;
using HealthcareManagementSystem.Application.DTOs;
using HealthcareManagementSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HealthcareManagementSystem.Tests.Controllers
{
    public class DoctorControllerTests
    {
        private readonly Mock<IDoctorService> _doctorServiceMock;
        private readonly DoctorController _doctorController;

        public DoctorControllerTests()
        {
            _doctorServiceMock = new Mock<IDoctorService>();
            _doctorController = new DoctorController(_doctorServiceMock.Object);
        }

        [Fact]
        public async Task GetDoctors_ReturnsOkResult_WithListOfDoctors()
        {
            // Arrange
            var doctors = new List<DoctorDto>
            {
                new DoctorDto { Id = 1, FullName = "John Doe", SpecializationName = "Cardiology" },
                new DoctorDto { Id = 2, FullName = "Jane Smith", SpecializationName = "Neurology" }
            };
            _doctorServiceMock.Setup(service => service.GetDoctorsAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                              .ReturnsAsync(doctors);

            // Act
            var result = await _doctorController.GetDoctors();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnDoctors = Assert.IsType<List<DoctorDto>>(okResult.Value);
            Assert.Equal(2, returnDoctors.Count);
        }

        [Fact]
        public async Task GetDoctor_ReturnsNotFound_WhenDoctorDoesNotExist()
        {
            // Arrange
            int doctorId = 1;
            _doctorServiceMock.Setup(service => service.GetDoctorByIdAsync(doctorId))
                              .ReturnsAsync((DoctorForEditDto)null);

            // Act
            var result = await _doctorController.GetDoctor(doctorId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AddDoctor_ReturnsCreatedResult()
        {
            // Arrange
            var doctorDto = new DoctorForEditDto { Id = 1, FullName = "John Doe", SpecializationId = 1 };

            // Act
            var result = await _doctorController.AddDoctor(doctorDto);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
    }
}
