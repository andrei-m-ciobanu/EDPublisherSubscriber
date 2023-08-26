namespace EmergencyDepartment.SecondaryAdapter.Publisher.DTO
{
    internal class PatientMessage
    {
        public Guid PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime EncounterStartDate { get; set; }
        public TimeSpan? PatientAge { get; set; }
        public string? TriagePrediction { get; set; }
        public bool? IsSepsisRisk { get; set; }
        public BloodPressure? LatestBloodPressure { get; set; }
        public RespiratoryRate? LatestRespiratoryRate { get; set; }
        public Temperature? LatestTemperature { get; set; }
    }
}
