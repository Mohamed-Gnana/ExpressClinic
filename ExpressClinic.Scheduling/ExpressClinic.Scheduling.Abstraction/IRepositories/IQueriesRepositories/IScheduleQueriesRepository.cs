using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using ExpressClinic.SharedKernal.Abstraction.IRepositories;

namespace ExpressClinic.Scheduling.Abstraction.IRepositories.IQueriesRepositories
{
    public interface IScheduleQueriesRepository : IQueriesRepository<Schedule, Guid>
    {
        Task<Schedule?> GetScheduleForDate(int clinicId, DateTime date);
    }
}
