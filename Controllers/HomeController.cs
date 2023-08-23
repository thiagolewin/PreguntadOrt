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
        Juego.InicializarJuego();
        return View();
    }
    public IActionResult SinTiempo() {
        return View("Tiempo");
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
        Juego.inicioJuego = DateTime.Now;
        Pregunta preg = Juego.ObtenerProximaPregunta();
        if(preg == null) {
            return View("Fin");
        }
        ViewBag.Tiempo = Juego.inicioJuego;
        ViewBag.Pregunta = preg;
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(preg.IdPregunta);
        return View("Jugar");
    }
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta,string enunciado, string respuesta) {
        ViewBag.Correcta = Juego.VerificarRespuesta(idPregunta,idRespuesta);
        ViewBag.IdPregunta = idPregunta;
        ViewBag.Pregunta = enunciado;
        ViewBag.Respuesta = respuesta;
        ViewBag.Progreso = Juego._cantidadPreguntasCorrectas;
        ViewBag.Maximo = Juego._cantidadPreguntas;
        return View("Respuesta");
    }
        public IActionResult Reiniciar(int idPregunta) {
        Juego.inicioJuego = DateTime.Now;
        List<Pregunta> pregs = Juego._preguntas;
        Pregunta preg = new Pregunta();
        foreach(var i in pregs) {
            if (i.IdPregunta == idPregunta) {
                preg = i;
            }
        }
        ViewBag.Tiempo = Juego.inicioJuego;
        ViewBag.Pregunta = preg;
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(preg.IdPregunta);
        return View("Jugar");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
