namespace EmergencyDepartment.Domain.Models
{
    public class ManchesterTriagePrediction
    {
        public DateTime OccurenceDateTime { get; set; }
        public ManchesterTriageScale TriageLevel { get; set; }
        public bool MoreInputIsRequired { get; set; }
        public bool IsSepsisSuspicion { get; set; }
    }
}
