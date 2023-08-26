using EmergencyDepartment.SecondaryAdapter.Persistence.Entities;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.ModelToEntity
{
    internal static class TemperatureToEntityMapper
    {
        internal static Temperature ToEntity(this Domain.Models.Observations.Temperature model)
        {
            return new Temperature
            {
                Id = model.Id,
                ValueInCelsius = model.Value,
                EffectiveDateTime = model.EffectiveDateTime,
                PatientId = model.Patient.Id
            };
        }
    }
}
