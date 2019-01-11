using Application.Models;
using MediatR;

namespace Application.Features.Doctor.Commands.ReviewMedicalExamination
{
    public class ReviewMedicalExaminationCommand : UserIdentity, IRequest
    {
        public int? RequestId { get; set; }

        public bool? IsApproved { get; set; }
    }
}
