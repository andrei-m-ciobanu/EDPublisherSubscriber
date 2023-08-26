using EmergencyDepartment.SecondaryAdapter.Persistence.Entities;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.ModelToEntity
{
    internal static class RespiratoryRateToEntityMapper
    {
        internal static RespiratoryRate ToEntity(this Domain.Models.Observations.RespiratoryRate model)
        {
            return new RespiratoryRate
            {
                Id = model.Id,
                BreathsPerMin = model.Value,
                EffectiveDateTime = model.EffectiveDateTime,
                PatientId = model.Patient.Id
            };
        }
    }
}
