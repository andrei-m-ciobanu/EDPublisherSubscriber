using EmergencyDepartment.Domain.Models.Observations;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.EntityToModel
{
    internal static class RespiratoryRateToModelMapper
    {
        internal static RespiratoryRate ToModel(this Entities.RespiratoryRate entity)
        {
            return new RespiratoryRate
            {
                Value = entity.BreathsPerMin,
                EffectiveDateTime = entity.EffectiveDateTime,
            };
        }
    }
}
