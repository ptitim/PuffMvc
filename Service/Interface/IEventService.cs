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

        List<EventDto> GetAllEvents();

        List<EventDto> GetAllPublishedEvent();

        EventDto GetEventById(int? id, out Treatment tr);

        #endregion



        #region Methods set

        EventDto SaveEvent(EventDto dto, out Treatment tr);

        void DeleteEvent(int id, out Treatment tr);

        void UpdateEvent(EventDto dto, out Treatment tr);

        #endregion

    }
}
