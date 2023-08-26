using EmergencyDepartment.Application.Ports.Secondary.Publisher;
using EmergencyDepartment.Domain.Models;
using EmergencyDepartment.SecondaryAdapter.Publisher.DTO;
using EmergencyDepartment.SecondaryAdapter.Publisher.Mappers;

namespace EmergencyDepartment.SecondaryAdapter.Publisher
{
    public class PublisherAdapter : IPublisherPort
    {
        private readonly IMessageQueuePublisher publisher;

        public PublisherAdapter(IMessageQueuePublisher publisher)
        {
            this.publisher = publisher;
        }

        public void SendNewPatientMessage(Patient patient)
        {
            var message = GetPatientMessage(patient);

            var routingKey = patient.LatestTriageLevel.HasValue
                ? $"patient.{GetTriageLevelRouting(patient.LatestTriageLevel.Value)}"
                : "patient";

            publisher.SendMessage(routingKey, message);
        }

        public void SendNewTriagePrediction(Patient patient, ManchesterTriagePrediction triagePrediction)
        {
            var message = GetPatientMessage(patient, triagePrediction);
            var routingKey = $"triage.{GetTriageLevelRouting(triagePrediction.TriageLevel)}";
            publisher.SendMessage(routingKey, message);
        }

        private static PatientMessage GetPatientMessage(Patient patient, ManchesterTriagePrediction? triagePrediction = null)
        {
            return new PatientMessage
            {
                PatientId = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                PatientAge = patient.GetAge(),
                TriagePrediction = triagePrediction?.TriageLevel.ToString(),
                IsSepsisRisk = triagePrediction?.IsSepsisSuspicion,
                LatestBloodPressure = patient.BloodPressures?
                    .OrderByDescending(p => p.EffectiveDateTime)
                    .FirstOrDefault()?.ToDTO(),
                LatestRespiratoryRate = patient.RespiratoryRates
                    .OrderByDescending(p => p.EffectiveDateTime)
                    .FirstOrDefault()?.ToDTO(),
                LatestTemperature = patient.Temperatures
                    .OrderByDescending(p => p.EffectiveDateTime)
                    .FirstOrDefault()?.ToDTO()
            };
        }

        private static string GetTriageLevelRouting(ManchesterTriageScale triageLevel)
        {
            return triageLevel.ToString().ToLower();
        }
    }
}