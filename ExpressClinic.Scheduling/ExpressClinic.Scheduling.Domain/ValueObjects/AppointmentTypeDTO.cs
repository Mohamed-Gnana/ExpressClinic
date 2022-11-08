using Ardalis.GuardClauses;
using ExpressClinic.SharedKernal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Domain.ValueObjects
{
    public class AppointmentTypeDTO : ValueObject
    {
        public AppointmentTypeDTO(int appointmentTypeId, double appointmentTypeDuration)
        {
            Id = Guard.Against.NegativeOrZero(appointmentTypeId, nameof(appointmentTypeId));
            Duration = Guard.Against.NegativeOrZero(appointmentTypeDuration, nameof(appointmentTypeDuration));
        }

        public int Id { get; private set; }
        public double Duration { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Duration;
        }
    }
}
