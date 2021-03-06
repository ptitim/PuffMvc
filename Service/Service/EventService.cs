﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataAccess.DAO;
using DataAccess.Entity;
using Newtonsoft.Json;
using Service.DTO;

namespace Service
{
    public class EventService : IEventService
    {
        #region Properties

        private EventDao _eventDao;

        private UserDao _userDao;

        private SeanceDao _seanceDao;

        private MovieDao _movieDao;
        #endregion

        #region Ctor

        public EventService()
        {
            _eventDao = new EventDao();
            _userDao = new UserDao();

            _seanceDao = new SeanceDao();
            _movieDao = new MovieDao();


        }

        #endregion


        #region Methods Get

        /// <summary>
        /// Get all events ordered by date
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<EventDto> GetAllEvents()
        {
            IEnumerable<Event> entities = new List<Event>();
            try
            {
                entities = _eventDao.GetAllEvents();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            List<EventDto> dtos = entities.Select(EventDto.Extract).ToList();
            return dtos;
        }

        /// <summary>
        /// Get all published events, ordered by date
        /// </summary>
        /// <returns></returns>
        public List<EventDto> GetAllPublishedEvent()
        {
            IEnumerable<Event> entities = new List<Event>();
            try
            {
                entities = _eventDao.GetAllPublishedEvent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            List<EventDto> dtos = entities.Select(EventDto.Extract).ToList();
            return dtos;
        }

        /// <summary>
        /// Get event by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public EventDto GetEventById(int? id, out Treatment tr)
        {
            tr = new Treatment();

            if (!id.HasValue)
            {
                tr.AddFatalErrorWithCode(HttpStatusCode.BadRequest);
                return null;
            }

            var foundEvent = _eventDao.GetEventById(id.Value);
            if (foundEvent == null)
            {
                tr.AddErrorWithCode(HttpStatusCode.NotFound);
                return null;
            }

            var eventDto = EventDto.Extract(foundEvent);
            tr.AddObject(eventDto);

            return eventDto;
        }

        /// <summary>
        /// Get the list of events by movies given
        /// </summary>
        /// <param name="moviesName"></param>
        /// <param name="maxPerLine">maximum number of event per line</param>
        /// <returns></returns>
        public List<EventListDto> GetListEventsByMovies(List<string> moviesName, int maxPerLine)
        {
            var entities = this._eventDao.GetEventsByMovies(moviesName);

            var movies = this._movieDao.GetMoviesByTitles(moviesName);

            var moviesEvents = new List<Tuple<Movie, List<Event>>>();

            foreach (var movie in movies)
            {
                // get events with seance of the movie
                var events = entities.Where(en => en.Seances.Any(sc => sc.Seance.Movie.Id == movie.Id)).Take(maxPerLine).ToList();
                if (events.Any())
                    moviesEvents.Add(Tuple.Create(movie, events));
            }

            List<EventListDto> dtos = new List<EventListDto>();

            if (entities != null)
            {
                foreach (var liste in moviesEvents)
                {
                    dtos.Add(EventListDto.Extract(liste.Item2, liste.Item1));
                }
            }

            return dtos;
        }

        #endregion

        #region Methods Set

        /// <summary>
        /// Save event modification
        /// Create a new one if none is found
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public EventDto SaveEvent(EventDto dto, out Treatment tr)
        {
            tr = new Treatment();

            if (dto == null)
            {
                tr.AddErrorWithCode(HttpStatusCode.BadRequest);
                return null;
            }

            var evvent = _eventDao.GetEventById(dto.Id);

            var newEvent = EventDto.Populate(dto, evvent);

            // Check if event is new
            if (evvent == null)
                _eventDao.AddEvent(newEvent);

            _eventDao.SaveChanges();

            dto = EventDto.Extract(newEvent);
            tr.AddObject(dto);

            return dto;
        }

        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tr"></param>
        public void DeleteEvent(int id, out Treatment tr)
        {
            tr = new Treatment();
            Event entity = null;

            // Get event
            try
            {
                entity = _eventDao.GetEventById(id);
            }
            catch (Exception exception)
            {
                tr.AddErrorWithCode(HttpStatusCode.NotFound, exception.ToString());
            }

            // try to delete event
            if (entity != null)
            {
                _eventDao.DeleteEvent(entity);
                tr.AddInfoWithCode(HttpStatusCode.NoContent, "Event has been deleted with success");
                _eventDao.SaveChanges();
            }
            else
            {
                tr.AddErrorWithCode(HttpStatusCode.NotFound, "Event has not been found");
            }

        }

        /// <summary>
        /// Update an event
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="tr"></param>
        public void UpdateEvent(EventDto dto, out Treatment tr)
        {
            tr = new Treatment();

            Event entity;

            try
            {
                entity = _eventDao.GetEventById(dto.Id);
            }
            catch (Exception ex)
            {
                tr.AddErrorWithCode(HttpStatusCode.NotFound, ex.ToString());
                return;
            }

            if (entity != null)
            {

                EventDto.Populate(dto, entity);

                _eventDao.SaveChanges();

                var updatedEvent = EventDto.Extract(entity);

                tr.AddObject(updatedEvent);
                tr.AddInfoWithCode(HttpStatusCode.Accepted, "Data updated with success");
            }
            else
            {
                tr.AddErrorWithCode(HttpStatusCode.NotFound, "Event has not been found");
            }
        }



        #endregion


    }
}