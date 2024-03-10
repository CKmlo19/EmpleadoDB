using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

namespace EmpleadoDB.Models
{
    // modelo del empleado con sus getters 
    public class EmpleadoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="El campo Nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\- ]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos y el guion '-'")] // expresion regular
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Salario es obligatorio")]
        public decimal Salario { get; set; }
    }
}
