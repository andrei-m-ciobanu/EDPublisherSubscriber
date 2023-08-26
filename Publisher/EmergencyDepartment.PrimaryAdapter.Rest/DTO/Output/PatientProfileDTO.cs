namespace EmergencyDepartment.PrimaryAdapter.Rest.DTO.Output
{
    public class PatientProfileDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public TimeSpan? Age { get; set; }
        public DateOnly? Birthdate { get; set; }

        public string? Urgency { get; set; }

    }
}
