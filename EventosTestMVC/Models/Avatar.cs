using System.ComponentModel.DataAnnotations.Schema;

namespace EventosTestMVC.Models
{
    public class Avatar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArchivoLottie { get; set; } // Puedes almacenar la ruta del avatar o el avatar como bytes, dependiendo de tu preferencia

        [NotMapped]
        public IFormFile ArchivoLottieFormFile { get; set; }
    }
}
