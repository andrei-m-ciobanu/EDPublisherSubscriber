using EmergencyDepartment.Domain.Models.Observations;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.EntityToModel
{
    internal static class BloodPressureToModelMapper
    {
        internal static BloodPressure ToModel(this Entities.BloodPressure entity)
        {
            return new BloodPressure
            {
                Id = entity.Id,
                Systolic = entity.Systolic,
                Diastolic = entity.Diastolic,
                EffectiveDateTime = entity.EffectiveDateTime,
            };
        }
    }
}
