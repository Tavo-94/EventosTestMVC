namespace EventosTestMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Lugar { get; set; }
        public string ListaCosasLlevar { get; set; }
        public string Clave { get; set; }
        public int UsuarioId { get; set; }
        public Usuario CreadorEvento { get; set; }
        public int TipoEventoId { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public int CodigoVestimentaId { get; set; }
        public CodigoVestimenta CodigoVestimenta { get; set; }

        public ICollection<Invitado> Invitados { get; set; } = new List<Invitado>();
        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
        public ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
        public int DiasRestantes
        {
            get
            {
                TimeSpan tiempoRestante = Fecha - DateTime.Now;
                return tiempoRestante.Days;
            }
        }

        public int HorasRestantes
        {
            get
            {
                TimeSpan tiempoRestante = Fecha - DateTime.Now;
                return tiempoRestante.Hours;
            }
        }

        public int MinutosRestantes
        {
            get
            {
                TimeSpan tiempoRestante = Fecha - DateTime.Now;
                return tiempoRestante.Minutes;
            }
        }
    }
}
