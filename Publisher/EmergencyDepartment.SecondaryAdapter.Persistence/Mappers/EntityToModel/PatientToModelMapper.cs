using EmergencyDepartment.Domain.Models;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.EntityToModel
{
    internal static class PatientToModelMapper
    {
        internal static Patient ToModel(this Entities.Patient entity)
        {
            var model = new Patient
            {
                Id = entity.Id,
                Birthdate = entity.Birthdate,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                LatestTriageLevel = (ManchesterTriageScale?)entity.TriageLevel
            };

            if (entity.BloodPressures != null)
            {
                model.BloodPressures = entity.BloodPressures!.Select(p => p.ToModel()).ToList();
            }

            if (entity.RespiratoryRates != null)
            {
                model.RespiratoryRates = entity.RespiratoryRates!.Select(p => p.ToModel()).ToList();
            }

            if (entity.Temperatures != null)
            {
                model.Temperatures = entity.Temperatures!.Select(p => p.ToModel()).ToList();
            }

            return model;
        }
    }
}
