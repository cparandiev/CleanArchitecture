namespace Application.Features.BodyExamination.Models
{
    public class BloodPressureExaminationDto
    {
        public int? Id { get; set; }

        public decimal? SystolicBloodPressure { get; set; }

        public decimal? DiastolicBloodPressure { get; set; }
    }
}
