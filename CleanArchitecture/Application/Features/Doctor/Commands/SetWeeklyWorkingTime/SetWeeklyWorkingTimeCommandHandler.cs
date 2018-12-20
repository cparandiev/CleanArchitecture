using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Doctor.Models;
using Application.Interfaces;
using Application.Specifications.DoctorSpecifications;
using AutoMapper;
using Domain.Entities.DoctorAggregate;
using MediatR;

namespace Application.Features.Doctor.Commands.SetWeeklyWorkingTime
{
    public class SetWeeklyWorkingTimeCommandHandler : IRequestHandler<SetWeeklyWorkingTimeCommand>
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _autoMapper;

        public SetWeeklyWorkingTimeCommandHandler(IUnitOfWork context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<Unit> Handle(SetWeeklyWorkingTimeCommand request, CancellationToken cancellationToken)
        {
            var doctorEntity = _context.Doctors.GetById(request.DoctorId.Value);

            var generatedWorkingTimes = request.WorkingTimes.SelectMany(w => {
                var tempWorkingTimes = new List<WorkingTimeUnit>();
                
                for (int i = 0; i < request.NumOfWeeks.Value; i++)
                    tempWorkingTimes.Add(new WorkingTimeUnit(){
                        Open = w.Open.Value.AddDays(7 * i),
                        Close = w.Close.Value.AddDays(7 * i)
                    });

                return tempWorkingTimes;
            });

            _autoMapper.Map<List<DoctorWorkingTime>>(generatedWorkingTimes).ForEach(w => {
                w.DoctorId = request.DoctorId.Value;
                doctorEntity.WorkingTimes.Add(w);
            });

            await _context.CompleteAsync();

            return Unit.Value;
        }
    }
}
