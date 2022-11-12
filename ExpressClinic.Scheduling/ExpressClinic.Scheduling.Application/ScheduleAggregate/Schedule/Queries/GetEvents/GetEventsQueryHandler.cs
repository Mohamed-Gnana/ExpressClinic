using ExpressClinic.Scheduling.Abstraction.IRepositories.IQueriesRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Application.ScheduleAggregate.Schedule.Queries.GetEvents
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, List<Domain.ScheduleAggregate.Schedule>>
    {
        private readonly IScheduleQueriesRepository _repository;

        public GetEventsQueryHandler(IScheduleQueriesRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Domain.ScheduleAggregate.Schedule>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return _repository.ListAsync();
        }
    }
}
