using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using ExpressClinic.SharedKernal.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExpressClinic.Scheduling.Infrastructure.Data.SQLServer
{
    public class ScheduleDbContext: DbContext
    {
        private readonly IMediator _mediator;

        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_mediator is null) return result;

            var entitiesWithEvents = ChangeTracker
                .Entries()
                .Select(x => x.Entity as BaseEntityWithDomainEvents<Guid>)
                .Where(x => x?.Events is not null && x.Events.Any())
                .ToArray();

            if (entitiesWithEvents is null) return result;

            foreach(var entity in entitiesWithEvents)
            {
                if (entity is null) continue;

                var events = entity.Events.ToArray();
                entity.Events.Clear();

                foreach(var domainEvent in events)
                {
                    await _mediator.Send(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            if (_mediator is null) return result;

            var entitiesWithEvents = ChangeTracker
                .Entries()
                .Select(x => x.Entity as BaseEntityWithDomainEvents<Guid>)
                .Where(x => x?.Events is not null && x.Events.Any())
                .ToArray();

            if(entitiesWithEvents is null) return result;

            foreach(var entity in entitiesWithEvents)
            {
                if (entity is null) continue;

                var events = entity.Events.ToArray();
                entity.Events.Clear();

                foreach(var domainEvent in events)
                {
                    _mediator.Send(domainEvent).GetAwaiter().GetResult();
                }
            }

            return result;
        }
    }
}
