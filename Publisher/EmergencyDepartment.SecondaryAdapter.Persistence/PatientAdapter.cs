using EmergencyDepartment.Application.Ports.Secondary.Persistance;
using EmergencyDepartment.Domain.Models.Observations;
using EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.EntityToModel;
using EmergencyDepartment.SecondaryAdapter.Persistence.Mappers.ModelToEntity;
using Microsoft.EntityFrameworkCore;

namespace EmergencyDepartment.SecondaryAdapter.Persistence
{
    public class PatientAdapter : IPatientPort
    {
        private readonly EmergencyDepartmentDbContext dbContext;

        public PatientAdapter(EmergencyDepartmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Domain.Models.Patient AddPatient(Domain.Models.Patient model)
        {
            var patientEntity = model.ToEntity();
            dbContext.Patients.Add(patientEntity);
            dbContext.SaveChanges();
            model.Id = patientEntity.Id;
            return model;
        }

        public Guid AddObservation(ObservationBase observation)
        {
            dynamic entity;
            switch(observation)
            {
                case Domain.Models.Observations.BloodPressure bloodPressure:
                    entity = bloodPressure.ToEntity();
                    break;

                case Domain.Models.Observations.Temperature temperature:
                    entity = temperature.ToEntity();
                    break;

                case Domain.Models.Observations.RespiratoryRate respiratoryRate:
                    entity = respiratoryRate.ToEntity();
                    break;

                default:
                    throw new NotImplementedException("This should never happe");
            }

            dbContext.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        private Guid AddBloodPressure(Domain.Models.Observations.BloodPressure bloodPressure)
        {
            var entity = bloodPressure.ToEntity();
            dbContext.BloodPressures.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        private Guid AddTemperature(Domain.Models.Observations.Temperature temperature)
        {
            var entity = temperature.ToEntity();
            dbContext.Temperatures.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        private Guid AddRespiratoryRate(Domain.Models.Observations.RespiratoryRate respiratoryRate)
        {
            var entity = respiratoryRate.ToEntity();
            dbContext.RespiratoryRates.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        public Domain.Models.Patient? GetById(Guid id)
        {
            var patient = dbContext.Patients.Find(id);
            return patient?.ToModel();
        }

        public Domain.Models.Patient? GetPatientWithDataById(Guid id)
        {
            var patient = dbContext.Patients.Where(p => p.Id == id)
                .Include(p => p.BloodPressures)
                .Include(p => p.Temperatures)
                .Include(p => p.RespiratoryRates)
                .FirstOrDefault();

            if (patient == null)
            {
                return null;
            }

            return patient.ToModel();
        }
    }
}
