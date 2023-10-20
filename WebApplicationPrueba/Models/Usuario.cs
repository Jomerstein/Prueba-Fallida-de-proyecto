using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPrueba.Models
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }
        public string email { get; set; }
        public string contrasenia { get; set; }
        
        public List<Entrada> entradasUsuario { get; set; }
        public List<Espectaculo> espectaculosUsuario { get; set; }

        public Usuario(string nombre, string apellido, string email, string contrasenia) { 
            this.nombre = nombre;   this.apellido = apellido;
            this.email = email; 
            entradasUsuario = new List<Entrada>();
            this.espectaculosUsuario = new List<Espectaculo>();
        
        }
        public Usuario() { }


    }
}
