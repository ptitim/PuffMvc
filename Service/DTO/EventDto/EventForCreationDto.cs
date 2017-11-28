using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class EventForCreationDto
    {
        #region Properties

        public string Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Resumer { get; set; }

        public string RendezVousPoint { get; set; }

        public int? NbMaxOfParticipant { get; set; }

        public bool? IsPublished { get; set; }

        #endregion

        #region Static list

        public List<MovieDto> Movies { get; set; }

        public List<SeanceDto> Seances { get; set; }

        #endregion

        #region Ctor

        #endregion

        #region Méthods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userId">Id of the user creating the event.</param>
        /// <returns></returns>
        public static Event Populate(EventForCreationDto dto, string userId, Event entity = null)
        {
            if (entity == null)
                entity = new Event();

            entity.Name = dto.Name;
            entity.Description = dto.Name;
            entity.NbMaxOfParticipant = dto.NbMaxOfParticipant ?? 0;
            entity.Resume = dto.Resumer;

            entity.RendezVousPoint = dto.RendezVousPoint;
            entity.IsPublished = dto.IsPublished ?? false;

            return entity;
        }

        #endregion

    }
}
