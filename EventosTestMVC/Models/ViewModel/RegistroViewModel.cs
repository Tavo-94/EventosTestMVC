using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventosTestMVC.Models.ViewModel
{
    public class RegistroViewModel
    {
        public UsuarioEntity? Usuario { get; set; }
        public List<SelectListItem>? Avatares { get; set; }
    }
}
