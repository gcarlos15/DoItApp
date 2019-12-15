using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoIt.Modelos
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Título requerido.")]
        [StringLength(45, ErrorMessage = "Longitud de caracteres invalido. (Máx:45)")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descripción requerido.")]
        [StringLength(75, ErrorMessage = "Longitud de caracteres invalido. (Máx:75)")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Fecha de tarea requerida.")]
        public DateTime Fecha { get; set; }

        public DateTime CreatedAt()
        {
            return DateTime.Now;
        }

        public int Hecho { get; set; }
    }
}
