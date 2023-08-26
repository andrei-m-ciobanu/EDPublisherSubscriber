using EmergencyDepartment.Domain.Exceptions;
using EmergencyDepartment.Domain.Models.Observations;

namespace EmergencyDepartment.Domain.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime EncounterStartDate { get; set; }
        public DateTime? EncounterEndDate { get; set; }

        public DateOnly? Birthdate { get; set; }

        public ManchesterTriageScale? LatestTriageLevel { get; set; }

        public List<BloodPressure> BloodPressures { get; set; } = new List<BloodPressure>();
        public List<Temperature> Temperatures { get; set; } = new List<Temperature>();
        public List<RespiratoryRate> RespiratoryRates { get; set; } = new List<RespiratoryRate>();

        public TimeSpan? GetAge()
        {
            if (Birthdate == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;

            return now - Birthdate.Value.ToDateTime(TimeOnly.FromDateTime(now));
        }

        public void ValidateOrThrow()
        {
            var now = DateTime.UtcNow;
            if (Birthdate.HasValue 
                && (Birthdate.Value.ToDateTime(TimeOnly.FromDateTime(now)) > DateTime.UtcNow 
                    || Birthdate.Value.Year < 1900))
            {
                throw new OutOfRangeException("Birthdate is in the future or is wrong");
            }
        }
    }
}
