namespace EmergencyDepartment.Domain.Exceptions
{
    public abstract class EDException : Exception
    {
        public EDException() { }
        public EDException(string message) : base(message) { }
    }
}
