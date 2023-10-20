using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplicationPrueba.Models
{
    public class Entrada
    {
        [Key]
        public string codigo { get; set; }

        public Boolean esValida { get; set; }

        public Entrada() {
            this.esValida = true;

            this.codigo = generarCodigo();
        }   
        
        private string generarCodigo()
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            for(int i = 0; i < 30; i++)
            {
                int c = random.Next(caracteres.Length);
                stringBuilder.Append(caracteres[c]);
            }
            
            return stringBuilder.ToString();
        }
    }
}
