using Microsoft.AspNetCore.Mvc;
using EmpleadoDB.Models;
using EmpleadoDB.Data;

namespace EmpleadoDB.Controllers
{
    public class EmpleadoController : Controller
    {

        EmpleadoDatos _EmpleadoDatos = new EmpleadoDatos();

        public IActionResult Listar()
        {
            // la lista mostrara una lista de empleados
            var oLista = _EmpleadoDatos.Listar(); // llama al metodo de listar y lo muestra
            return View(oLista); 
        }
        public IActionResult Insertar()
        {
            // muestra el formulario para insertar
            return View();
        }
        [HttpPost]
        public IActionResult Insertar(EmpleadoModel oEmpleado)
        {
            // este otro es para capturar los datos y enviarlo a la base de datos

            var resultado = _EmpleadoDatos.Insertar(oEmpleado);

            if (resultado)
            {
                return RedirectToAction("Listar");

            }
            else{ 
                return View();
             }
        }
    }
}
