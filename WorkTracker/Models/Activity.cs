using Microsoft.AspNetCore.Identity;

namespace WorkTracker.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public DateOnly Date { get; set; }
        public int ActivityTypeId { get; set; }

        public virtual ActivityType? ActivityType { get; set; }

        public string? UserId { get; set; }

        public IdentityUser? User { get; set; }
    }
}
