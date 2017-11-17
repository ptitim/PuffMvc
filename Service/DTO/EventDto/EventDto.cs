﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataAccess.Entity;

namespace Service.DTO
{
    public class EventDto : IDto
    {
        #region Properties

        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "ResumeTitle", ResourceType = typeof(Common.Resources.EventResources))]
        public string Resume { get; set; }

        [Display(Name = "NumberOfParticipantTItle", ResourceType = typeof(Common.Resources.EventResources))]
        public int NumberMaxOfParticipant { get; set; }

        public string RendezVousPoint { get; set; }

        public bool? IsPublished { get; set; }

        public string CreatorName { get; set; }

        public List<SeanceDto> Seance { get; set; }

        public int NumberOfParticipant { get; set; }

        public List<UserDto> Participants { get; set; }

        public List<UserDto> Hosts { get; set; }

        #endregion

        #region Ctor

        public EventDto()
        {
        }

        public EventDto(string name, DateTime date, int? nbMaxParticipant, bool isPublished)
        {
            Name = name;
            Date = date;
            NumberMaxOfParticipant = nbMaxParticipant ?? 0;
            IsPublished = isPublished;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Extract event entity into event Dto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EventDto Extract(Event entity)
        {
            var dto = new EventDto();

            if (entity == null) return dto;

            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Date = entity.Date;
            dto.IsPublished = entity.IsPublished;
            dto.Description = entity.Description;
            dto.Resume = entity.Resume;

            dto.NumberMaxOfParticipant = entity.NbMaxOfParticipant;
            dto.RendezVousPoint = entity.RendezVousPoint;

            dto.NumberOfParticipant = entity.Participants.Count;

            dto.CreatorName = entity.Creator.UserName;

            // Get participants
            if (entity.Participants != null && entity.Participants.Any())
                dto.Participants = entity.Participants.Select(pr => UserDto.Extract(pr.User)).ToList();

            // Get hosts
            if (entity.Hosts != null && entity.Hosts.Any())
                dto.Hosts = entity.Hosts.Select(hs => UserDto.Extract(hs.User)).ToList();

            //dto.Seance = SeanceDto.Extract(entity.Seances);
            if (entity.Seances != null && entity.Seances.Any())
                dto.Seance = entity.Seances.Select(sc => SeanceDto.Extract(sc.Seance)).ToList();

            return dto;
        }

        public static Event Populate(EventDto dto, Event entity = null, User creator = null)
        {
            // create new event if none exists
            if (entity == null)
                entity = new Event();

            // Populate data
            if (!string.IsNullOrEmpty(dto.Name))
                entity.Name = dto.Name;

            if (dto.Date != default(DateTime))
                entity.Date = dto.Date;

            if (!string.IsNullOrEmpty(dto.Description))
                entity.Description = dto.Description;

            if (dto.NumberMaxOfParticipant != default(int))
                entity.NbMaxOfParticipant = dto.NumberMaxOfParticipant;

            if (!string.IsNullOrEmpty(dto.Resume))
                entity.Resume = dto.Resume;

            if (!string.IsNullOrEmpty(dto.RendezVousPoint))
                entity.RendezVousPoint = dto.RendezVousPoint;

            if (dto.IsPublished.HasValue)
                entity.IsPublished = dto.IsPublished.Value;

            if (creator != null && entity.Creator == null)
                entity.Creator = creator;

            if (dto.Seance != null && dto.Seance.Any())
            {
                foreach (var seanceDto in dto.Seance)
                {
                    var tmp = entity.Seances.FirstOrDefault(se => se.SeanceId == seanceDto.Id);
                    if (tmp != null)
                    {
                        tmp.Seance = SeanceDto.Populate(seanceDto, tmp.Seance);
                    }
                    else
                    {
                        tmp = new SeanceEvent() { EventId = dto.Id, Seance = SeanceDto.Populate(seanceDto) };
                    }
                }
            }


            return entity;
        }

        #endregion
    }
}