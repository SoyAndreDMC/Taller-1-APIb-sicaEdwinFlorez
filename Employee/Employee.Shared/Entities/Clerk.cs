using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Shared.Entities
{
    public class Clerk
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Apellido")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "Fecha de contratación")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateOnly HireDate { get; set; }

        [Display(Name = "Salario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1000000, double.MaxValue, ErrorMessage = "El campo {0} debe ser minimo{1}.")]
        public float Salary { get; set; }
    }
}