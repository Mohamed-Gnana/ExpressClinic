using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using ExpressClinic.SharedKernal.Abstraction.IRepositories;

namespace ExpressClinic.Scheduling.Abstraction.IRepositories.ICommandsRepositories
{
    public interface IScheduleCommandsRepository : ICommandsRepository<Schedule, Guid>
    {
    }
}
