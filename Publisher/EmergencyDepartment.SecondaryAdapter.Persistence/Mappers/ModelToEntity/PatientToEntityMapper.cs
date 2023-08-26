using EmergencyDepartment.SecondaryAdapter.Persistence.Entities;

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.ModelToEntity
{
    internal static class PatientToEntityMapper
    {
        internal static Patient ToEntity(this Domain.Models.Patient model)
        {
            return new Patient
            {
                Id = model.Id,
                Birthdate = model.Birthdate,
                FirstName = model.FirstName,
                LastName = model.LastName,
                TriageLevel = (int?)(model!.LatestTriageLevel), 
                EncounterStartDate = model.EncounterStartDate
            };
        }
    }
}
