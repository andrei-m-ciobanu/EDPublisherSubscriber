using EmergencyDepartment.Application.Services.TriageAlgorithms;
using EmergencyDepartment.Domain.Models;
using EmergencyDepartment.Domain.Models.Observations;

namespace EmergencyDepartment.Application.Test.Services.TriageAlgorithms
{
    public class ManchesterTriageSepsisAlgorithmTest
    {
        private readonly IManchesterTriageSepsisAlgorithm triageSepsisAlgorithm;

        public ManchesterTriageSepsisAlgorithmTest()
        {
            triageSepsisAlgorithm = new ManchesterTriageSepsisAlgorithm();
        }

        [Fact]
        public void ShouldReturnMoreInformationIsNeeded_WhenTriageWithoutAnyObservations()
        {
            var triagePrediction = triageSepsisAlgorithm.Run(new Patient());

            Assert.NotNull(triagePrediction);
            Assert.True(triagePrediction.MoreInputIsRequired);
            Assert.Equal(ManchesterTriageScale.NonUrgent, triagePrediction.TriageLevel);
            
        }

        [Fact]
        public void ShouldReturnStandard_WhenPatientWithoutAnyObservationsAndTriagedStandard()
        {
            var triagePrediction = triageSepsisAlgorithm.Run(new Patient
            {
                LatestTriageLevel = ManchesterTriageScale.Standard
            });

            Assert.NotNull(triagePrediction);
            Assert.True(triagePrediction.MoreInputIsRequired);
            Assert.Equal(ManchesterTriageScale.Standard, triagePrediction.TriageLevel);
        }

        [Fact]
        public void ShouldReturnVeryUrgentWithSepsisSuspicion_WhenPatientWithObservations()
        {
            var triagePrediction = triageSepsisAlgorithm.Run(
                GetSepsisPatientWithStandardInitialTriage());

            Assert.NotNull(triagePrediction);
            Assert.False(triagePrediction.MoreInputIsRequired);
            Assert.True(triagePrediction.IsSepsisSuspicion);
            Assert.Equal(ManchesterTriageScale.VeryUrgent, triagePrediction.TriageLevel);
        }

        private static Patient GetSepsisPatientWithStandardInitialTriage()
        {
            var sepsisPatient = new Patient
            {
                Id = Guid.NewGuid(),
                LatestTriageLevel = ManchesterTriageScale.Standard
            };

            sepsisPatient.Temperatures.Add(new Temperature 
            {
                Id = Guid.NewGuid(),
                EffectiveDateTime = DateTime.UtcNow,
                Value = 40.2,
                Patient = sepsisPatient
            });

            sepsisPatient.RespiratoryRates.Add(new RespiratoryRate 
            {
                Id = Guid.NewGuid(),
                EffectiveDateTime = DateTime.UtcNow,
                Value = 30,
                Patient = sepsisPatient
            });

            return sepsisPatient;
        }
    }
}
