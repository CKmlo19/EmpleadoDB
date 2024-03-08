using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

namespace EmpleadoDB.Models
{
    public class EmpleadoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Salario es obligatorio")]
        public decimal Salario { get; set; }
    }
}
