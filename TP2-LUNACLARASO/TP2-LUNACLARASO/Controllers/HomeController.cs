using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TP2_LUNACLARASO.Models;
using NLog;
namespace TP2_LUNACLARASO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Logger log)
        {
            _logger = (ILogger<HomeController>)log;
            _logger.LogInformation("a");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult tp2(string nombre, string apellido, string fechaIngreso)
        {
            try
            {
                if(nombre !=null && apellido !=null )
                {
                    DateTime fechaingreso = DateTime.Parse(fechaIngreso);
                    empleado newEmpleado = new empleado(nombre, apellido, fechaingreso);
                    _logger.LogInformation("fueron ingresados los siguientes datos: " + nombre + " " + apellido + ","  + newEmpleado.Antiguedad + " de antiguedad y salario $" + newEmpleado.Salario);
                    ViewBag.empleado = newEmpleado;

                }
                else
                {
                    ViewBag.mensaje = "Error, datos erroneos";
                    _logger.LogError("Datos erroneos");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                ViewBag.mensaje = "Datos erroneos";
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
