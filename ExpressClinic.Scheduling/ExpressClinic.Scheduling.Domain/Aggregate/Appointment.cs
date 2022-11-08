using Ardalis.GuardClauses;
using ExpressClinic.Scheduling.Domain.Events.DomainEvents;
using ExpressClinic.Scheduling.Domain.ValueObjects;
using ExpressClinic.SharedKernal.Domain.Aggregates;
using ExpressClinic.SharedKernal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.Aggregate
{
    public class Appointment: BaseEntity<Guid>
    {
        #region Private Fields

        private Guid _scheduleId;
        private int _appointmentTypeId;
        private int _doctorId;
        private int _patientId;
        private int _clientId;
        private int _roomId;
        private DateTimeOffsetRange _timeRange;
        private string _title;
        private DateTime? _dateTimeConfirmed = null;
        private bool _isPotentiallyConflicting = false;

        #endregion

        #region Constructors
        private Appointment() { }
        public Appointment(Guid id,
            int appointmentTypeId,
            Guid scheduleId,
            int clientId,
            int patientId,
            int doctorId,
            int roomId,
            DateTimeOffsetRange timeRange,
            string title,
            DateTime? dateTimeConfirmed = null)
        {
            Id = Guard.Against.Default(id, nameof(id));
            _appointmentTypeId = Guard.Against.NegativeOrZero(appointmentTypeId, nameof(appointmentTypeId));
            _scheduleId = Guard.Against.Default(scheduleId, nameof(scheduleId));
            _clientId = Guard.Against.NegativeOrZero(clientId, nameof(clientId));
            _patientId = Guard.Against.NegativeOrZero(patientId, nameof(patientId));
            _doctorId = Guard.Against.NegativeOrZero(doctorId, nameof(doctorId));
            _roomId = Guard.Against.NegativeOrZero(roomId, nameof(roomId));
            _timeRange = Guard.Against.Null(timeRange, nameof(timeRange));
            _title = Guard.Against.NullOrEmpty(title, nameof(title));
            _dateTimeConfirmed = dateTimeConfirmed;
        }
        #endregion

        #region Public Properties
        public Guid ScheduleId
        {
            get => _scheduleId;
            private set => _scheduleId = value;
        }

        public int AppointmentTypeId
        {
            get => _appointmentTypeId;
            private set => _appointmentTypeId = value;
        }

        public int ClientId
        {
            get => _clientId;
            private set => _clientId = value;
        }

        public int PatientId
        {
            get => _patientId;
            private set => _patientId = value;
        }

        public int DoctorId
        {
            get => _doctorId;
            private set => _doctorId = value;
        }

        public int RoomId
        {
            get => _roomId;
            private set => _roomId = value;
        }

        public DateTimeOffsetRange TimeRange
        {
            get => _timeRange;
            private set => _timeRange = value;
        }

        public string Title
        {
            get => _title;
            private set => _title = value;
        }

        public DateTime? DateTimeConfirmed
        {
            get => _dateTimeConfirmed;
            private set => _dateTimeConfirmed = value;
        }

        public bool IsPotentiallyConflict
        {
            get => _isPotentiallyConflicting;
            set => _isPotentiallyConflicting = value;
        }
        #endregion

        #region Public Methods
        public void UpdateRoom(int newRoomId)
        {
            Guard.Against.NegativeOrZero(newRoomId, nameof(newRoomId));
            if (newRoomId == _roomId) return;

            _roomId = newRoomId;

            var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
            this.Events.Add(appointmentUpdatedEvent);
        }

        public void UpdateDoctor(int newDoctorId)
        {
            Guard.Against.NegativeOrZero(newDoctorId, nameof(newDoctorId));
            if (newDoctorId == _doctorId) return;

            _doctorId = newDoctorId;

            var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
            this.Events.Add(appointmentUpdatedEvent);
        }

        public void UpdateStartTime(DateTimeOffset newStartTime, Action scheduleHandler)
        {
            if (newStartTime == _timeRange.Start) return;

            TimeRange = new DateTimeOffsetRange(newStartTime, TimeSpan.FromMinutes(_timeRange.DurationInMinutes()));

            scheduleHandler?.Invoke();

            var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
            this.Events.Add(appointmentUpdatedEvent);
        }

        public void UpdateTitle(string newTitle)
        {
            if (newTitle == _title) return;

            _title = newTitle;

            var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
            this.Events.Add(appointmentUpdatedEvent);
        }

        public void UpdateAppointmentType(AppointmentTypeDTO appointmentType, Action scheduleHandler)
        {
            Guard.Against.Null(appointmentType, nameof(appointmentType));

            if (appointmentType.Id == _appointmentTypeId) return;
            _timeRange = _timeRange.NewEnd(_timeRange.Start.AddMinutes(appointmentType.Duration));

            scheduleHandler?.Invoke();

            var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
            this.Events.Add(appointmentUpdatedEvent);
        }

        public void Confirm(DateTimeOffset dateConfirmed)
        {
            if (_dateTimeConfirmed.HasValue) return;

            DateTimeConfirmed = dateConfirmed.DateTime;

            var appointmentConfirmedEvent = new AppointmentConfirmedEvent(this);
            this.Events.Add(appointmentConfirmedEvent);
        }
        #endregion
    }
}
