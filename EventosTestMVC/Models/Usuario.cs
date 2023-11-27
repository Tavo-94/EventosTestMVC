namespace EventosTestMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int AvatarId { get; set; }
        public Avatar Avatar { get; set; }

        public ICollection<Evento> EventosCreados { get; set; } = new List<Evento>();
    }
}
