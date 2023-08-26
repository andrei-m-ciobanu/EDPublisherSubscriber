using EmergencyDepartment.Domain.Models;

namespace EmergencyDepartment.Application.Ports.Secondary.Publisher
{
    public interface IPublisherPort
    {
        void SendNewPatientMessage(Patient patient);
        void SendNewTriagePrediction(Patient patient, ManchesterTriagePrediction triagePrediction);
    }
}
