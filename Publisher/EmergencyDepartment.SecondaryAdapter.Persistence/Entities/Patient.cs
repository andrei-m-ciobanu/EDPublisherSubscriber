using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Entities
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime EncounterStartDate { get; set; }
        public DateTime? EncounterEndDate { get; set; }
        public int? TriageLevel { get; set; }
        public DateOnly? Birthdate { get; set; }
        public List<BloodPressure>? BloodPressures { get; set; }
        public List<Temperature>? Temperatures { get; set; }
        public List<RespiratoryRate>? RespiratoryRates { get; set; }
    }
}
