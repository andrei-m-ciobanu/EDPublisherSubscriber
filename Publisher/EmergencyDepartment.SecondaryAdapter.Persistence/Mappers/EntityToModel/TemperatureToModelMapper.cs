using EmergencyDepartment.Domain.Models.Observations;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.EntityToModel
{
    internal static class TemperatureToModelMapper
    {
        internal static Temperature ToModel(this Entities.Temperature entity)
        {
            return new Temperature
            {
                Id = entity.Id,
                Value = entity.ValueInCelsius,
                EffectiveDateTime = entity.EffectiveDateTime,
            };
        }
    }
}
