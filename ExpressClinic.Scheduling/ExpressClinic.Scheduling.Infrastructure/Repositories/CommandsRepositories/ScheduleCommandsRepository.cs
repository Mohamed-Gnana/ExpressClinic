using ExpressClinic.Scheduling.Abstraction.IRepositories.ICommandsRepositories;
using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using ExpressClinic.Scheduling.Infrastructure.Data.SQLServer;
using ExpressClinic.SharedKernal.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Infrastructure.Repositories
{
    public class ScheduleCommandsRepository : IScheduleCommandsRepository
    {
        private ScheduleDbContext _context;

        public ScheduleCommandsRepository(ScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<Schedule> AddAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public Task DeleteAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public async Task<Schedule> UpdateAsync(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }
    }
}
