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
        return RedirectToAction("ConfigurarJuego");
    }
    public IActionResult Comenzar() {
        Juego.CargarPartida(Juego._username,Juego.dificultad,Juego.categoria);
        return View("Jugar");
    }
    public IActionResult Jugar() {
        ViewBag.Pregunta = Juego.ObtenerProximaPregunta();
        if(ViewBag.Pregunta == null) {
            return view ("Fin");
        }
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(Pregunta.IdPregunta);
        return View("Juego");
    }
    [HttpPost] public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta) {
        ViewBag.Correcta = VerificarRespuesta(idPregunta,idRespuesta);
        return View("Respuesta");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
