using System.ComponentModel.DataAnnotations;

namespace WebApplicationPrueba.Models
{
    public class Espectaculo
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public DateTime fecha { get; set; }
        public Boolean visibilidad { get; set; }
        [Key]
        public int idEspectaculo { get; set; }
    }
}
