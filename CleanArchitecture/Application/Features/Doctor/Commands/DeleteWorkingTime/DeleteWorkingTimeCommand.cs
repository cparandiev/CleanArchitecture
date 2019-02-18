using Application.Models;
using MediatR;

namespace Application.Features.Doctor.Commands.DeleteWorkingTime
{
    public class DeleteWorkingTimeCommand : UserIdentity, IRequest
    {
        public int? WorkingTimeId { get; set; }
    }
}
