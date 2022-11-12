using ExpressClinic.SharedKernal.Domain.Events.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Abstraction.IServices
{
    public interface IBaseMessagePublisher
    {
        void Publish(BaseIntegrationEvent eventToPublish);
    }
}
