using EmergencyDepartment.Domain.Models;

namespace EmergencyDepartment.Application.Services.TriageAlgorithms
{
    public interface IManchesterTriageSepsisAlgorithm
    {
        ManchesterTriagePrediction Run(Patient patient);
    }
}
