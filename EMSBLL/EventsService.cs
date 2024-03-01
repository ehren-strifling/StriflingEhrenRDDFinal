using EMSENTITIES;
using EMSDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSBLL
{
    public class EventsService
    {
        public List<Events> GetEvents()
        {
            return new EventsRepository().GetEvents();
        }

        public Events GetEventsById(int id)
        {
            //TEMP. This can later be expanded with a full sql method to get an event by id
            return this.GetEvents().Where(x => x.EventID == id).FirstOrDefault();
        }

        public bool CreateEventsService(Events events)
        {
            return new EventsRepository().CreateEvents(events);
        }

        public bool UpdateEventsService(Events events)
        {
            return new EventsRepository().UpdateEvents(events);
        }

        public bool DeleteEventsService(int eventId)
        {
            return new EventsRepository().DeleteEvents(eventId);
        }
    }
}
