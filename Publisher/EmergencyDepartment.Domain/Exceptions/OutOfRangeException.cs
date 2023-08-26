namespace EmergencyDepartment.Domain.Exceptions
{
    public class OutOfRangeException : EDException
    {
        public OutOfRangeException(string message) : base(message)
        {
        }
    }
}
