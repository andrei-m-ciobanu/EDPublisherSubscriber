namespace EmergencyDepartment.PrimaryAdapter.Rest.DTO.Input
{
    public class Patient
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateOnly? Birthdate { get; set; }
        
        public DateTime AdmissionDateTime { get; set; }

        public int? Urgency { get; set; }
    }
}
