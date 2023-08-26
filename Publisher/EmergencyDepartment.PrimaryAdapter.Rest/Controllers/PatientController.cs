using EmergencyDepartment.Application.Ports.Primary;
using EmergencyDepartment.PrimaryAdapter.Rest.DTO.Output;
using Microsoft.AspNetCore.Mvc;
using BloodPressure = EmergencyDepartment.Domain.Models.Observations.BloodPressure;
using BloodPressureDTO = EmergencyDepartment.PrimaryAdapter.Rest.DTO.Input.BloodPressure;
using RespiratoryRate = EmergencyDepartment.Domain.Models.Observations.RespiratoryRate;
using RespiratoryRateDTO = EmergencyDepartment.PrimaryAdapter.Rest.DTO.Input.RespiratoryRate;
using Patient = EmergencyDepartment.Domain.Models.Patient;
using PatientDTO = EmergencyDepartment.PrimaryAdapter.Rest.DTO.Input.Patient;
using Temperature = EmergencyDepartment.Domain.Models.Observations.Temperature;
using TemperatureDTO = EmergencyDepartment.PrimaryAdapter.Rest.DTO.Input.Temperature;
using System.ComponentModel;
using System.Net;

namespace EmergencyDepartment.PrimaryAdapter.Rest.Controllers
{
    [ApiController]
    [Route("patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService service)
        {
            this.patientService = service;
        }

        [HttpGet]
        [Route("{patientId}")]
        public PatientProfileDTO GetById(Guid patientId)
        {
            var patient = patientService.GetById(patientId);
            return new PatientProfileDTO
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate,
                Age = patient.GetAge(),
                Urgency = patient.LatestTriageLevel?.ToString()
            };
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public void CreatePatient(PatientDTO patient)
        {
            var patientId = patientService.RegisterPatient(new Patient
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                LatestTriageLevel = patient.Urgency.HasValue
                    ? (Domain.Models.ManchesterTriageScale)patient.Urgency.Value
                    : null,
                Birthdate = patient.Birthdate,
                EncounterStartDate = patient.AdmissionDateTime
            });
            Response.Headers.Add("Location", $"/patients/{patientId}");
            Response.StatusCode = StatusCodes.Status204NoContent;
        }

        [HttpPost]
        [Route("{patientId}/observations/blood-pressure")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public void CreateBloodPressure(Guid patientId, BloodPressureDTO bloodPressure)
        {
            patientService.AddObservation(patientId, new BloodPressure 
                {
                    Systolic = bloodPressure.Sys,
                    Diastolic = bloodPressure.Dia,
                    EffectiveDateTime = bloodPressure.ObservedAt,
                });
            Response.StatusCode = StatusCodes.Status204NoContent;
        }

        [HttpPost]
        [Route("{patientId}/observations/temperature")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public void CreateTemperature(Guid patientId, TemperatureDTO temperature)
        {
            patientService.AddObservation(patientId, new Temperature()
            {
                Value = temperature.ValueInCelsius,
                EffectiveDateTime = temperature.ObservedAt,
            });
            Response.StatusCode = StatusCodes.Status204NoContent;
        }

        [HttpPost]
        [Route("{patientId}/observations/respiratory-rate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public void CreateHertRate(Guid patientId, RespiratoryRateDTO espiratoryRate)
        {
            patientService.AddObservation(patientId, new RespiratoryRate()
            {
                Value = espiratoryRate.Bpm,
                EffectiveDateTime = espiratoryRate.ObservedAt,
            });
            Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
