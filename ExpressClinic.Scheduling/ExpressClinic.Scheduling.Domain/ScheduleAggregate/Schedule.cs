using Ardalis.GuardClauses;
using ExpressClinic.Scheduling.Domain.Events.DomainEvents;
using ExpressClinic.Scheduling.Domain.ScheduleAggregate.Guards;
using ExpressClinic.SharedKernal.Domain.Aggregates;

namespace ExpressClinic.Scheduling.Domain.ScheduleAggregate
{
    public class Schedule : BaseEntityWithDomainEventsAndIntegrationEvents<Guid>, IAggregateRoot
    {
        #region Priavate Fields
        private int _clinicId;
        private DateTimeOffset _dateRange;
        private readonly List<Appointment> _appointments = new List<Appointment>();
        #endregion

        #region Constructors
        public Schedule(Guid id, int clinicId)
        {
            Id = id;
            _clinicId = clinicId;
        }

        public Schedule(Guid id, DateTimeOffset dateRange, int clinicId)
        {
            Id = id;
            _dateRange = dateRange;
            _clinicId = clinicId;
        }
        #endregion

        #region Public Properties
        public int ClinicId
        {
            get => _clinicId;
            private set => _clinicId = value;
        }

        public DateTimeOffset DateRange
        {
            get => _dateRange;
            private set => _dateRange = value;
        }

        public IEnumerable<Appointment> Appointments => _appointments.AsReadOnly();
        #endregion

        #region Public Methods

        public Appointment AddNewAppointment(Appointment appointment)
        {
            Guard.Against.Null(appointment, nameof(appointment));
            Guard.Against.Default(appointment.Id, nameof(appointment.Id));
            Guard.Against.DuplicateAppointment(_appointments, appointment, nameof(appointment));

            _appointments.Add(appointment);

            MarkConflictingAppointments();

            var appointmentScheduledEvent = new AppointmentScheduledEvent(appointment);
            Events.Add(appointmentScheduledEvent);

            return appointment;
        }

        public void DeleteAppointment(Appointment appointment)
        {
            Guard.Against.Null(appointment, nameof(appointment));

            var appointmentToDelete = _appointments
                .FirstOrDefault(a => a.Id == appointment.Id);

            if (appointmentToDelete is null) return;

            _appointments.Remove(appointment);

            MarkConflictingAppointments();

            var appointmentDeletedEvent = new AppointmentDeletedEvent(appointment);
            Events.Add(appointmentDeletedEvent);
        }

        private void MarkConflictingAppointments()
        {
            foreach (var appointment in _appointments)
            {
                var potentiallyConflictingAppointmentsForPatients = _appointments
                    .Where(a => a.PatientId == appointment.PatientId &&
                    a.TimeRange.Overlaps(appointment.TimeRange) &&
                    a.Id != appointment.Id)
                    .ToList();

                var potentiallyConflictingAppointmentsForRooms = _appointments
                    .Where(a => a.RoomId == appointment.RoomId &&
                    a.TimeRange.Overlaps(appointment.TimeRange) &&
                    a.Id != appointment.Id)
                    .ToList();

                var potentiallyConflictingAppointmentsForDoctors = _appointments
                    .Where(a => a.DoctorId == appointment.DoctorId &&
                    a.TimeRange.Overlaps(appointment.TimeRange) &&
                    a.Id != appointment.Id)
                    .ToList();

                potentiallyConflictingAppointmentsForPatients.ForEach(a => a.IsPotentiallyConflict = true);
                potentiallyConflictingAppointmentsForDoctors.ForEach(a => a.IsPotentiallyConflict = true);
                potentiallyConflictingAppointmentsForRooms.ForEach(a => a.IsPotentiallyConflict = true);

                appointment.IsPotentiallyConflict = potentiallyConflictingAppointmentsForRooms.Any() ||
                    potentiallyConflictingAppointmentsForPatients.Any() ||
                    potentiallyConflictingAppointmentsForDoctors.Any();
            }
        }

        #endregion
    }
}
