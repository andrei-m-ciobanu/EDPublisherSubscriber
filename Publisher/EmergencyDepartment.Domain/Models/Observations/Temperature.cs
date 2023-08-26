using EmergencyDepartment.Domain.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace EmergencyDepartment.Domain.Models.Observations
{
    public class Temperature : SingleValueObservationBase<double>
    {
        [SetsRequiredMembers]
        public Temperature()
        {
            Unit = "Celsius";
        }

        public override void ValidateOrThrowException()
        {
            if (Value == 0)
            {
                throw new ValueNotProvidedException();
            }
        }
    }
}
