using EmergencyDepartment.SecondaryAdapter.Publisher.DTO;

namespace EmergencyDepartment.SecondaryAdapter.Publisher.Mappers
{
    internal static class TemperatureMapper
    {
        internal static Temperature ToDTO(this Domain.Models.Observations.Temperature temperature)
        {
            return new Temperature
            {
                Effective = temperature.EffectiveDateTime,
                ValueInCelsius = temperature.Value
            };
        }
    }
}
