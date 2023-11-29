namespace EventosTestMVC.Models
{
    public class AvatarUser
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<UsuarioEntity> Usuario { get; set; }
    }
}