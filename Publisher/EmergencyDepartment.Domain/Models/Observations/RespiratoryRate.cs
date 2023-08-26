using EmergencyDepartment.Domain.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace EmergencyDepartment.Domain.Models.Observations
{
    public class RespiratoryRate : SingleValueObservationBase<int>
    {
        [SetsRequiredMembers]
        public RespiratoryRate()
        {
            Unit = "BreathsPerMinute";
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
