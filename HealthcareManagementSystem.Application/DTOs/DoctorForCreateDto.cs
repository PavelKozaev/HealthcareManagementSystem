namespace HealthcareManagementSystem.Application.DTOs
{
    public class DoctorForCreateDto
    {
        public string FullName { get; set; }
        public int OfficeId { get; set; }
        public int SpecializationId { get; set; }
        public int? PlotId { get; set; }
    }
}
