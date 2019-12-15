using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoIt.Modelos
{
    public class Persona
    {
        [Required(ErrorMessage = "Nombre requerido.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nombre. No se admiten números, " +
                                                        "carácteres especiales ni espacios en blanco")]
        [StringLength(45,ErrorMessage = "Longitud de caracteres invalido. (Máx:45)")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido requerido.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Apellido. No se admiten números, " +
                                                        "carácteres especiales ni espacios en blanco")]
        [StringLength(75, ErrorMessage = "Longitud de caracteres invalido. (Máx:75)")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Edad requerida.")]
        [RegularExpression(@"^([1-9]\d?)?$", ErrorMessage = "Se espera una edad comprendida entre 1 y 99")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Genero requerido.")]
        public int Genero { get; set; }
    }
}
