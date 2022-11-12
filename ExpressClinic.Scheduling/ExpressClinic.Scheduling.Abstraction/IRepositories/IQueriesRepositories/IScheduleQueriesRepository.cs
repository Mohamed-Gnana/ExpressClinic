using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using ExpressClinic.Scheduling.Shared.Models;
using ExpressClinic.SharedKernal.Abstraction.IRepositories;
using System.Linq.Expressions;

namespace ExpressClinic.Scheduling.Abstraction.IRepositories.IQueriesRepositories
{
    public interface IScheduleQueriesRepository : IQueriesRepository<Schedule, Guid>
    {
        Task<Schedule?> GetScheduleForDate(int clinicId, DateTime date);
        Task<List<ScheduleDto>> GetAll(Expression<Func<List<ScheduleDto>, bool>> spec);
    }
}
