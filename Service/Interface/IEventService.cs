using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface IEventService
    {
        #region Methods get

        /// <summary>
        /// Get all events
        /// </summary>
        /// <returns></returns>
        List<EventDto> GetAllEvents();

        /// <summary>
        /// Get all published events
        /// </summary>
        /// <returns></returns>
        List<EventDto> GetAllPublishedEvent();

        /// <summary>
        /// Get one event by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        EventDto GetEventById(int? id, out Treatment tr);

        /// <summary>
        /// Get a list of event list dto , by movies
        /// </summary>
        /// <param name="movies"></param>
        /// <returns>
        /// {
        ///     "movie" : string,
        ///     "events : List<eventDto>
        /// }
        /// </returns>
        List<EventListDto> GetListEventsByMovies(List<string> movies);


        void fakeEvent();

        #endregion



        #region Methods set

        EventDto SaveEvent(EventDto dto, out Treatment tr);

        void DeleteEvent(int id, out Treatment tr);

        void UpdateEvent(EventDto dto, out Treatment tr);

        #endregion

    }
}
