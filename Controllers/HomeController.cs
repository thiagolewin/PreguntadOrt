using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PreguntadOrt.Models;

namespace PreguntadOrt.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ConfigurarJuego() {
        Juego.InicializarJuego();
        return View("ConfigurarJuego");
    }
    public IActionResult CambiarConfig(string _username, int dificultad, int categoria) {
        Juego.CargarPartida(_username,dificultad,categoria);
        return View("Index");
    }
    public IActionResult Jugar() {
        Pregunta preg = Juego.ObtenerProximaPregunta();
        if(preg == null) {
            return View("Fin");
        }
        ViewBag.Pregunta = preg;
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(preg.IdPregunta);
        return View("Jugar");
    }
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta,string enunciado, string respuesta) {
        ViewBag.Correcta = Juego.VerificarRespuesta(idPregunta,idRespuesta);
        ViewBag.Pregunta = enunciado;
        ViewBag.Respuesta = respuesta;
        return View("Respuesta");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
