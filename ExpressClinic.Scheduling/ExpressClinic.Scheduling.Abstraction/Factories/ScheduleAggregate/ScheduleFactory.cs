using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Abstraction.Factories.ScheduleAggregate
{
    public class ScheduleFactory
    {
        private Guid _id;
        private int _clinicId;
        private DateTime _start;
        private DateTime _end;
        private List<Guid> _appointments = new List<Guid>();
        private ScheduleFactory(Guid id, int clinicId)
        {
            _id = id;
            _clinicId = clinicId;
        }

        public ScheduleFactory WithStartDate(DateTime? start)
        {
            if (start is null) return this;
            _start = start.Value;
            return this;
        }

        public ScheduleFactory WithEndDate(DateTime? end)
        {
            if (end is null) return this;
            _end = end.Value;
            return this;
        }

        public ScheduleFactory WithAppointments(List<Guid>? appointments)
        {
            if (appointments is null || appointments.Count == 0) return this;
            _appointments.AddRange(appointments);
            return this;
        }

        public Schedule Build()
        {
            var dateRange = new DateTimeOffset(_start, TimeSpan.FromMinutes((_end.Subtract(_start)).TotalMinutes));
            var schedule = new Schedule(_id, dateRange, _clinicId);
            // _appointments.ForEach(x => x = x/*Assign Appointments */);
            return schedule;
        }

        public static ScheduleFactory Create(int clinicId)
        {
            return new ScheduleFactory(Guid.NewGuid(), clinicId);
        }


    }
}
