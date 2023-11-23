using System.ComponentModel.DataAnnotations.Schema;

namespace EventosTestMVC.Models
{
    public class Event
    {

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime Hora { get; set; }

        //extras
        public string Lugar { get; set; }
        public Vestimenta Vestimenta { get; set; } //falta tabla
        public string ListaCosas { get; set; }

        public string? PlannerEmail { get; set; }



        //nav to planner 1 to m
        public Planner Planner { get; set; }

        //nav to user
        public ICollection<User> Users { get; set; }
        public ICollection<EventToUsers> EventToUsers { get; set; }

        //nav comments
        public ICollection<UserComment> UserComments { get; set; }
        public ICollection<PlannerComment> PlannerComments { get; set; }

        //nav props for tags relation m to m
        public ICollection<Tag> Tags { get; set; }
        public ICollection<TagsToEvent> TagEvents { get; set; }

        //nav props for Supply

        public ICollection<Supply> Supplies { get; set; }

    }
}