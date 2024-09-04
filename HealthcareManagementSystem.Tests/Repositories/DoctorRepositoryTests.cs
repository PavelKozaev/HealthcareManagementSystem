using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Infrastructure.Data;
using HealthcareManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManagementSystem.Tests.Repositories
{
    public class DoctorRepositoryTests
    {
        private readonly HealthcareDbContext _context;
        private readonly DoctorRepository _doctorRepository;

        public DoctorRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<HealthcareDbContext>()
                          .UseInMemoryDatabase(databaseName: "HealthcareTestDb")
                          .Options;
            _context = new HealthcareDbContext(options);
            _doctorRepository = new DoctorRepository(_context);
        }

        [Fact]
        public async Task AddAsync_ShouldAddDoctor()
        {
            // Arrange
            var doctor = new Doctor { FullName = "John Doe", SpecializationId = 1 };

            // Act
            await _doctorRepository.AddAsync(doctor);
            var result = await _context.Doctors.FindAsync(doctor.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John Doe", result.FullName);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnDoctor()
        {
            // Arrange
            var doctor = new Doctor { FullName = "Jane Smith", SpecializationId = 1 };
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            // Act
            var result = await _doctorRepository.GetByIdAsync(doctor.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Jane Smith", result.FullName);
        }
    }
}
