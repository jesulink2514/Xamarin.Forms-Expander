using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace AgendaApp
{
    public interface IEventsService
    {
        [Get("/sesiones")]
        Task<Session[]> GetSessions();
    }

    public class Session
    {
        public int idSesion { get; set; }
        public string nombreSesion { get; set; }
        public DateTime fecha { get; set; }
        public string color { get; set; }
        public Asistente[] asistentes { get; set; }
    }

    public class Asistente
    {
        public int idAsistente { get; set; }
        public string nombre { get; set; }
        public DateTime fechaAsistencia { get; set; }
    }

}
