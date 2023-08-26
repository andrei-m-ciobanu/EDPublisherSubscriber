using EmergencyDepartment.Domain.Models;
using EmergencyDepartment.Domain.Models.Observations;

namespace EmergencyDepartment.Application.Ports.Secondary.Persistance
{
    public interface IPatientPort
    {
        Patient? GetById(Guid patientId);
        Guid AddObservation(ObservationBase observation);
        Patient? GetPatientWithDataById(Guid id);

        Patient AddPatient(Patient patient);
    }
}
