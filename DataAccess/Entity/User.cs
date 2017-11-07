using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class User : IdentityUser
    {
        
        public InfoUser InfoUser { get; set; }
        
        public ICollection<Event> CreatedEvents { get; set; }
        
        public ICollection<EventParticipants> ParticpationEvents { get; set; }
        
        public ICollection<EventHosts> HostEvents { get; set; }
        
        public ICollection<Vote> Votes { get; set; }

        public User()
        {
            ParticpationEvents = new HashSet<EventParticipants>();
            HostEvents = new HashSet<EventHosts>();
            CreatedEvents = new HashSet<Event>();
            Votes = new HashSet<Vote>();
        }
    }
}