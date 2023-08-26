using EmergencyDepartment.Domain.Exceptions;

namespace EmergencyDepartment.Domain.Models.Observations
{
    public abstract class SingleValueObservationBase<T> : ObservationBase where T : struct
    {
        public T Value { get; set; }
        public required string Unit { get; set; }
    }
}
