namespace EventosTestMVC.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Guid? EventoId { get; set; }


        public int? CategoryId { get; set; }


        public EventoEntity EventoEntity { get; set; }
        public Category Category { get; set; }

    }
}
