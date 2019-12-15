using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoIt.Modelos
{
    public class Cuenta
    {
        [Required(ErrorMessage = "Nombre de usuario requerido.")]
        [StringLength(25, ErrorMessage = "Longitud de caracteres invalido. (Máx:25)")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Contraseña requerida.")]
        [RegularExpression(@"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$",
                            ErrorMessage = "La contraseña debe tener al entre 8 y 16 caracteres, " +
                                             "al menos un dígito, al menos una minúscula y al menos una mayúscula."
                                            + "NO puede tener otros símbolos.")]
        public string Contrasena { get; set; }
    }
}
