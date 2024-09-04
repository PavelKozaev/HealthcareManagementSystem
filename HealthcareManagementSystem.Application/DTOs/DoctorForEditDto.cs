namespace HealthcareManagementSystem.Application.DTOs
{
    public class DoctorForEditDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int OfficeId { get; set; }
        public int SpecializationId { get; set; }
        public int? PlotId { get; set; }
    }
}
