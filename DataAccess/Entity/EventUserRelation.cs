﻿namespace DataAccess.Entity
{
    public class EventParticipants
    {
        public string UserId { get; set; }
        public User User { get; set; }
        
        
        public int EventId { get; set; }
        public Event Event { get; set; }
    }

    public class EventHosts
    {
        public string UserId { get; set; }
        public User User { get; set; }
        
        public int EventId { get; set; }
        public Event Event { get; set; }
        
    }
}