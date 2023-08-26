namespace EmergencyDepartment.Domain.Models.Observations
{
    public abstract class ObservationBase
    {
        public Guid Id { get; set; }
        public Patient? Patient { get; set; }
        public DateTime EffectiveDateTime { get; set; }

        public abstract void ValidateOrThrowException();
    }
}
