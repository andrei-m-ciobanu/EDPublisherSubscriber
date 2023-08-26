using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Entities
{
    public class BloodPressure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public Guid PatientId { get; set; }
        public DateTime EffectiveDateTime { get; set; }
    }
}
