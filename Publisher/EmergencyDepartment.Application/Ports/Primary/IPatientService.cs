using EmergencyDepartment.Domain.Models;
using EmergencyDepartment.Domain.Models.Observations;

namespace EmergencyDepartment.Application.Ports.Primary
{
    public interface IPatientService
    {
        Guid RegisterPatient(Patient patient);
        Guid AddObservation(Guid patientId, ObservationBase observation);
        Patient GetById(Guid id);
    }
}
