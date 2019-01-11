using Application.Models;
using MediatR;

namespace Application.Features.Doctor.Commands.AccomplishMedicalExamination
{
    public class AccomplishMedicalExaminationCommand : UserIdentity, IRequest
    {
        public int? RequestId { get; set; }

        public string Notes { get; set; }
    }
}
