using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Data.SqlTypes;

namespace EmpleadoDB.Models
{
    public class EmpleadoModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Salario { get; set; }
    }
}
