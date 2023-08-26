using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Entities
{
    public class Temperature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public double ValueInCelsius { get; set; }
        public Guid PatientId { get; set; }
        public DateTime EffectiveDateTime { get; set; }
    }
}
