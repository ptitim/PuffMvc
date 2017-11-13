using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class EventListDto
    {
        #region Properties

        public string MovieName;

        public List<EventDto> Events;
        #endregion

        #region Methods

        public static EventListDto Extract(List<Event> entity, string movieName)
        {
            var eventList = new EventListDto();
            eventList.MovieName = movieName;
            eventList.Events = entity.Select(en => EventDto.Extract(en)).ToList();

            return eventList;
        }

        #endregion

    }
}
