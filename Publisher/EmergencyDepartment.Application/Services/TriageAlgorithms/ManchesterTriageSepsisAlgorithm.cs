using EmergencyDepartment.Domain.Models;

namespace EmergencyDepartment.Application.Services.TriageAlgorithms
{
    public class ManchesterTriageSepsisAlgorithm : IManchesterTriageSepsisAlgorithm
    {
        private static readonly double TEMP_THRESHOLD = 37.5;
        private static readonly int SYSTOLIC_THRESHOLD = 100;
        private static readonly int RESPIRATORY_RATE_THRESHOLD = 22;

        public ManchesterTriagePrediction Run(Patient patient)
        {
            var temperature = patient.Temperatures.OrderByDescending(p => p.EffectiveDateTime).FirstOrDefault();
            var respiratoryRate = patient.RespiratoryRates.OrderByDescending(p => p.EffectiveDateTime).FirstOrDefault();
            var bloodPressure = patient.BloodPressures.OrderByDescending(p => p.EffectiveDateTime).FirstOrDefault();

            var countNullOrMissing = (temperature == null ? 1 : 0) 
                + (respiratoryRate == null ? 1 : 0) 
                + (bloodPressure == null ? 1 : 0);

            var prediction = new ManchesterTriagePrediction 
            { 
                OccurenceDateTime = DateTime.UtcNow,
                TriageLevel = patient.LatestTriageLevel ?? ManchesterTriageScale.NonUrgent
            };

            if (countNullOrMissing >= 2)
            {
                prediction.MoreInputIsRequired = true;
                return prediction;
            }

            // Sepsis check
            if ((temperature == null
                    && respiratoryRate!.Value > RESPIRATORY_RATE_THRESHOLD && bloodPressure!.Systolic < SYSTOLIC_THRESHOLD)
                || (respiratoryRate == null 
                    && temperature!.Value > TEMP_THRESHOLD && bloodPressure!.Systolic < SYSTOLIC_THRESHOLD)
                || (bloodPressure == null 
                    && temperature!.Value > TEMP_THRESHOLD && respiratoryRate!.Value > RESPIRATORY_RATE_THRESHOLD)
                || (countNullOrMissing == 0 
                    && temperature!.Value > TEMP_THRESHOLD 
                    && respiratoryRate!.Value > RESPIRATORY_RATE_THRESHOLD 
                    && bloodPressure!.Systolic < SYSTOLIC_THRESHOLD))
            {
                prediction.IsSepsisSuspicion = true;
                prediction.TriageLevel = ManchesterTriageScale.VeryUrgent;
                prediction.MoreInputIsRequired = false;
            }

            if (prediction.TriageLevel > patient?.LatestTriageLevel)
            {
                prediction.TriageLevel = patient.LatestTriageLevel.Value;
            }

            return prediction;
        }
    }
}
