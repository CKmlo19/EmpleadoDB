using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.Data.SqlTypes;

namespace EmpleadoDB.Models
{
    public class EmpleadoModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public SqlMoney Salario { get; set; }
    }
}
