using System.ComponentModel.DataAnnotations.Schema;

namespace EventosTestMVC.Models
{
    public class AvatarUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RutaJson { get; set; }

        public ICollection<UsuarioEntity> Usuario { get; set; }
    }
}