namespace EmergencyDepartment.PrimaryAdapter.Rest.DTO.Input
{
    public class ObservationValue<T> where T : struct
    {
        public T Value { get; set; }
        public required string Unit { get; set; }
        public bool CanDocument { get; set; }
        public DateTime ObservedAt { get; set; }
    }
}
