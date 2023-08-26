using EmergencyDepartment.Domain.Exceptions;

namespace EmergencyDepartment.Domain.Models.Observations
{
    public class BloodPressure : ObservationBase
    {
        public int Systolic { get; set; }
        public int Diastolic { get; set; }

        public override void ValidateOrThrowException()
        {
            if (Systolic < 0)
            {
                throw new OutOfRangeException("Systolic must be a positive value");
            }

            if (Diastolic < 0)
            {
                throw new OutOfRangeException("Diastolic must be a positive value");
            }
        }
    }
}
