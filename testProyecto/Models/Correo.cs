using System.ComponentModel.DataAnnotations;

namespace testProyecto.Models
{
    public class Correo
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="El correo es obligatorio")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        public string Cliente { get; set; }
        
        public string Principal {  get; set; }   
    }
}
