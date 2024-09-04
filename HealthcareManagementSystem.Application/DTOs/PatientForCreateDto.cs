namespace HealthcareManagementSystem.Application.DTOs
{
    public class PatientForCreateDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int PlotId { get; set; }
    }
}
