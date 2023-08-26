using EmergencyDepartment.Application.Ports.Primary;
using EmergencyDepartment.Application.Ports.Secondary.Persistance;
using EmergencyDepartment.Application.Ports.Secondary.Publisher;
using EmergencyDepartment.Application.Services;
using EmergencyDepartment.Application.Services.TriageAlgorithms;
using EmergencyDepartment.Domain.Exceptions;
using EmergencyDepartment.Domain.Models;
using Moq;

namespace EmergencyDepartment.Application.Test.Services
{
    public  class PatientServiceTest
    {
        private Mock<IPatientPort> patientPort = new Mock<IPatientPort>();
        private Mock<IPublisherPort> publisherPort = new Mock<IPublisherPort>();
        private Mock<IManchesterTriageSepsisAlgorithm> sepsisAlgorithm = 
            new Mock<IManchesterTriageSepsisAlgorithm>();

        private IPatientService patientService;

        public PatientServiceTest()
        {
            patientService = new PatientService(
                sepsisAlgorithm.Object,
                patientPort.Object, 
                publisherPort.Object);
        }

        [Fact]
        public void ShouldThrowException_WhenCreatePatientWithBirthdateInTheFuture()
        {
            var patient = new Patient
            {
                Birthdate = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
            };

            var exception = Record.Exception(() => patientService.RegisterPatient(patient));
            Assert.NotNull(exception);

            var domainEx = exception as OutOfRangeException;
            Assert.NotNull(domainEx);
        }

        [Fact]
        public void ShoudlReturnPatientWithId_WhenCreatingValidPatient()
        {
            var patient = new Patient();
            var patientId = Guid.NewGuid();

            patientPort
                .Setup(s => s.AddPatient(It.Is<Patient>(p => p == patient)))
                .Returns(new Patient { Id = patientId });

            var returnedPatientId = patientService.RegisterPatient(patient);
            Assert.Equal(patientId, returnedPatientId);
        }
    }
}
