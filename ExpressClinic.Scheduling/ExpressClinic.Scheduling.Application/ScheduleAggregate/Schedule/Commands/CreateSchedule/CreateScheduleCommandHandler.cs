using ExpressClinic.Scheduling.Abstraction.Factories.ScheduleAggregate;
using ExpressClinic.Scheduling.Abstraction.IRepositories.ICommandsRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Application.ScheduleAggregate.Schedule.Commands.CreateSchedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Domain.ScheduleAggregate.Schedule>
    {
        private readonly IScheduleCommandsRepository _repository;

        public CreateScheduleCommandHandler(IScheduleCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.ScheduleAggregate.Schedule> Handle(CreateScheduleCommand command, CancellationToken cancellationToken)
        {
            var scheduleFactory = ScheduleFactory.Create(command.ClientId)
                                            .WithStartDate(command.Start)
                                            .WithEndDate(command.End)
                                            .WithAppointments(command.AppointmentIds);

            var schedule = scheduleFactory.Build();
            schedule = await _repository.AddAsync(schedule);

            return schedule;
        }
    }
}
