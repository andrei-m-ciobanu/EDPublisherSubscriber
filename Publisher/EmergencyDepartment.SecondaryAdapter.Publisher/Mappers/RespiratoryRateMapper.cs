using EmergencyDepartment.SecondaryAdapter.Publisher.DTO;

namespace EmergencyDepartment.SecondaryAdapter.Publisher.Mappers
{
    internal static class RespiratoryRateMapper
    {
        internal static RespiratoryRate ToDTO(this Domain.Models.Observations.RespiratoryRate respiratoryRate) 
        {
            return new RespiratoryRate 
            {
                Effective = respiratoryRate.EffectiveDateTime, 
                Bpm = respiratoryRate.Value
            };
        }
    }
}
