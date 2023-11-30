namespace EventosTestMVC.Models
{
    public class EventoEntity
    {
        public Guid Id { get; set; }

        //titulo = nombre
        public string Titulo { get; set; }
        //descripcion = lugar
        public string Descripcion { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime FechaDeEvento { get; set; }
        public int? CodigoVestimentaId { get; set; }
        public int? TipoEventoId { get; set; }

        //hora de evento


        //tipo de evento
        //comprobante

        public ICollection<UsuarioEntity> Usuarios { get; set; }
        public ICollection<UsuarioToEvento> UsuarioToEventos { get; set; }

        //nav comments
        public ICollection<UserComment> UserComments { get; set; }

        //nav props for tags relation m to m
        public ICollection<Tag> Tags { get; set; }
        public ICollection<TagsToEvent> TagEvents { get; set; }

        //nav props for Supply

        public ICollection<Supply> Supplies { get; set; }

        //nav codigo de vestimenta
        public CodigoVestimenta CodigoVestimenta { get; set; }

        //nav codigo de TipoEvento
        public TipoEvento TipoEvento { get; set; }




        public int DiasRestantes
        {
            get
            {
                TimeSpan tiempoRestante = FechaDeEvento - DateTime.Now;
                return tiempoRestante.Days;
            }
        }

        public int HorasRestantes
        {
            get
            {
                TimeSpan tiempoRestante = FechaDeEvento - DateTime.Now;
                return tiempoRestante.Hours;
            }
        }

        public int MinutosRestantes
        {
            get
            {
                TimeSpan tiempoRestante = FechaDeEvento - DateTime.Now;
                return tiempoRestante.Minutes;
            }
        }
    }
}
