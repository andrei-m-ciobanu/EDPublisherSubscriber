using EmergencyDepartment.Domain.Exceptions;
using EmergencyDepartment.Domain.Models;

namespace EmergencyDepartment.Domain.Tests.Models
{
    // Test class for the Domain.Models.Patient
    public class PatientTests
    {
        [Fact]
        public void ShouldCalculateAge_WhenBirthdateIsPresentAndNotYetCelebrated()
        {
            var birthdate10YearsAgo = DateTime.Today.AddYears(-10).AddDays(10);

            var patient = new Patient
            {
                Birthdate = DateOnly.FromDateTime(birthdate10YearsAgo)
            };

            patient.ValidateOrThrow();

            var age = patient.GetAge();
            var ageInYears = age.Value.Days / 365;
            Assert.Equal(9, ageInYears);
        }

        [Fact]
        public void ShouldCalculateAge_WhenBirthdateIsPresentAndWasAlreadyCelebrated()
        {
            var birthdate10YearsAgo = DateTime.Today.AddYears(-10).AddDays(-5);

            var patient = new Patient
            {
                Birthdate = DateOnly.FromDateTime(birthdate10YearsAgo)
            };

            var age = patient.GetAge();
            var ageInYears = age.Value.Days / 365;
            Assert.Equal(10, ageInYears);
        }

        [Fact]
        public void ShouldCalculateAge_WhenBirthdateIsToday()
        {
            var birthdate10YearsAgo = DateTime.Today.AddYears(-10);

            var patient = new Patient
            {
                Birthdate = DateOnly.FromDateTime(birthdate10YearsAgo)
            };

            var age = patient.GetAge();
            var ageInYears = age.Value.Days / 365;
            Assert.Equal(10, ageInYears);
        }

        [Fact]
        public void ShouldNotCalculateAgen_WhenBirthdateIsNotPresent()
        {
            var patient = new Patient();
            patient.ValidateOrThrow();
            var age = patient.GetAge();
            Assert.Null(age);
        }

        [Fact]
        public void ShouldThrowOutOfRangeException_WhenValidateAndBirthdayIsInTheFuture()
        {
            var tomorrow = DateTime.Now.AddDays(1);
            var patient = new Patient
            {
                Birthdate = DateOnly.FromDateTime(tomorrow)
            };

            var exception = Record.Exception(patient.ValidateOrThrow);
            Assert.NotNull(exception);

            var domainEx = exception as OutOfRangeException;
            Assert.NotNull(domainEx);
        }

    }
}
