﻿namespace EventosTestMVC.Models.ViewModel
{
    public class DetalleEventoViewModel
    {
        public EventoEntity Evento { get; set; }
        public string Rol { get; set; }
        public string UserId { get; set; }
        public ICollection<UserComment> Comentarios { get; set; }
        public UserComment Comentario { get; set; }
    }
}