using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica.Areas.Users.Models
{
    public class InputModelRegister
    {
        //atributos de validacion.

        [Required(ErrorMessage = "El campo Nombre no puede estar vacio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Apellido no puede estar vacio")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo DUI no puede estar vacio")]
        public string DUI { get; set; }

        [Required(ErrorMessage = "El campo Telefono no puede estar vacio")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{5})$", ErrorMessage = "<font color ='red'>El formato de telefono ingresado no es valido")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El Campo correo electronico es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo correo electronico no es una direccion de correo electronico valida")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo contraseña es  obligatorio")]
        [StringLength(100, ErrorMessage = "El numero de caracteres de {0} debe ser al menos {2}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
