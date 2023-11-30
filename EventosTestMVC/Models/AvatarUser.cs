using System.ComponentModel.DataAnnotations.Schema;

namespace EventosTestMVC.Models
{
    public class AvatarUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArchivoLottie { get; set; }

        public ICollection<UsuarioEntity> Usuario { get; set; }
        [NotMapped]
        public IFormFile ArchivoLottieFormFile { get; set; }
    }
}