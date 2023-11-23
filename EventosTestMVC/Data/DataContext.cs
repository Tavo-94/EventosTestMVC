 using EventosTestMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventosTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vestimenta> Vestimenta { get; set; }

        //Entities

        public DbSet<User> Users { get; set; }
        public DbSet<Planner> Planners { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventToUsers> EventsToUsers { get; set; }

        public DbSet<AvatarUser> AvatarUsers { get; set; }
        public DbSet<AvatarPlanner> AvatarPlanners { get; set; }

        //comments
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<PlannerComment> PlannerComments { get; set; }

        //tags
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagsToEvent> TagsToEvents { get; set; }


        //supply
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Category> Categories { get; set; }

        
    }
    
}
