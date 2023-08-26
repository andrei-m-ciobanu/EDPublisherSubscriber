using EmergencyDepartment.Application.Ports.Primary;
using EmergencyDepartment.Application.Ports.Secondary.Persistance;
using EmergencyDepartment.Application.Ports.Secondary.Publisher;
using EmergencyDepartment.Application.Services.TriageAlgorithms;
using EmergencyDepartment.Domain.Exceptions;
using EmergencyDepartment.Domain.Models;
using EmergencyDepartment.Domain.Models.Observations;

namespace EmergencyDepartment.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientPort patientPort;
        private readonly IPublisherPort publisherPort;
        private readonly IManchesterTriageSepsisAlgorithm sepsisAlgorithm;

        public PatientService(IManchesterTriageSepsisAlgorithm sepsisAlgorithm, IPatientPort patientPort, 
            IPublisherPort publisherPort)  
        {
            this.sepsisAlgorithm = sepsisAlgorithm;
            this.patientPort = patientPort;
            this.publisherPort = publisherPort;
        }

        public Guid AddObservation(Guid patientId, ObservationBase observation)
        {
            observation.ValidateOrThrowException();

            var patient = patientPort.GetById(patientId) ?? throw new PatientNotFoundException();
            observation.Patient = patient;
            
            var observationId = patientPort.AddObservation(observation);

            var patientData = patientPort.GetPatientWithDataById(patientId);
            var prediction = sepsisAlgorithm.Run(patientData!);
            publisherPort.SendNewTriagePrediction(patientData!, prediction);

            return observationId;
        }

        public Guid RegisterPatient(Patient patient)
        {
            patient.ValidateOrThrow();
            var patientId = patientPort.AddPatient(patient).Id;
            publisherPort.SendNewPatientMessage(patient);
            return patientId;
        }

        public Patient GetById(Guid patientId)
        {
            return patientPort.GetById(patientId) ?? throw new PatientNotFoundException();
        }
    }
}
