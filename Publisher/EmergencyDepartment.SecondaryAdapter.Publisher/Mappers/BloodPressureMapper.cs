using EmergencyDepartment.SecondaryAdapter.Publisher.DTO;

namespace EmergencyDepartment.SecondaryAdapter.Publisher.Mappers
{
    internal static class BloodPressureMapper
    {
        internal static BloodPressure ToDTO(this Domain.Models.Observations.BloodPressure bloodPressure)
        {
            return new BloodPressure
            {
                Effective = bloodPressure.EffectiveDateTime,
                Systolic = bloodPressure.Systolic,
                Diastolic = bloodPressure.Diastolic
            };
        }
    }
}
