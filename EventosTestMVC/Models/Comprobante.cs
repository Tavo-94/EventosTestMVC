namespace EventosTestMVC.Models
{
    public class Comprobante
    {
        public int Id { get; set; }
        public byte[] Archivo { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
