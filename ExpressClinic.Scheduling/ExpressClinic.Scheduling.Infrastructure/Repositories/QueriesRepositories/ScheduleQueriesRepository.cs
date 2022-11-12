using ExpressClinic.Scheduling.Abstraction.IRepositories.IQueriesRepositories;
using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using ExpressClinic.Scheduling.Infrastructure.Data.SQLServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Infrastructure.Repositories.QueriesRepositories
{
    public class ScheduleQueriesRepository : IScheduleQueriesRepository
    {
        private readonly ScheduleDbContext _context;

        public ScheduleQueriesRepository(ScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(Expression<Func<Schedule, bool>> spec)
        {
            return await _context.Schedules.Where(spec).CountAsync();
        }

        public async Task<Schedule?> GetAsync(Expression<Func<Schedule, bool>> spec)
        {
            return await _context.Schedules.Where(spec).FirstOrDefaultAsync(); 
        }

        public async Task<Schedule?> GetByIdAsync(Guid id)
        {
            return await _context.Schedules.FirstAsync(x => x.Id == id);
        }

        public async Task<Schedule?> GetScheduleForDate(int clinicId, DateTime date)
        {
            return await _context.Schedules.FirstOrDefaultAsync();
        }

        public async Task<List<Schedule>> ListAsync()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task<List<Schedule>> ListAsync(Expression<Func<Schedule, bool>> spec)
        {
            return await _context.Schedules.Where(spec).ToListAsync();
        }
    }
}
