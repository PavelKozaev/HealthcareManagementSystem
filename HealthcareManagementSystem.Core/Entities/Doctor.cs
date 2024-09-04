namespace HealthcareManagementSystem.Core.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int OfficeId { get; set; }
        public int SpecializationId { get; set; }
        public int? PlotId { get; set; }

        public Office Office { get; set; }
        public Specialization Specialization { get; set; }
        public Plot Plot { get; set; }
    }
}
