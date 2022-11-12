using ExpressClinic.Scheduling.Domain.ScheduleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.Scheduling.Infrastructure.Data.SQLServer.Configurations
{
    internal class AppointmentConfigurations : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments").HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.OwnsOne(x => x.TimeRange, x =>
            {
                x.Property(xx => xx.Start).HasColumnName("StartDateTime");
                x.Property(xx => xx.End).HasColumnName("EndDateTime");
            });
        }
    }
}
