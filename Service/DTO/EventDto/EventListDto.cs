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

        public string Image;

        public List<EventDto> Events;
        #endregion

        #region Methods

        public static EventListDto Extract(List<Event> entity, Movie movie)
        {
            var eventList = new EventListDto
            {
                MovieName = movie.Name,
                Image = movie.Image,
                Events = entity.Select(en => EventDto.Extract(en)).ToList()
            };

            return eventList;
        }

        #endregion

    }
}
