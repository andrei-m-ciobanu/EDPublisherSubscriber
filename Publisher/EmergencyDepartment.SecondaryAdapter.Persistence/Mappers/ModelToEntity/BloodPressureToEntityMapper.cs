using EmergencyDepartment.SecondaryAdapter.Persistence.Entities;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.ModelToEntity
{
    internal static class BloodPressureToEntityMapper
    {
        internal static BloodPressure ToEntity(this Domain.Models.Observations.BloodPressure model)
        {
            return new BloodPressure
            {
                Id = model.Id,
                Systolic = model.Systolic,
                Diastolic = model.Diastolic,
                EffectiveDateTime = model.EffectiveDateTime,
                PatientId = model.Patient.Id
            };
        }
    }
}
