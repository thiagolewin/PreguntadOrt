public static class Juego {
    public static string _username {get; private set;} = "";
    public static int dificultad {get; private set;} = 1;
    public static int categoria {get; private set;} = 1;
    public static int _puntajeActual {get; private set;}
    public static int _cantidadPreguntasCorrectas { get; private set;} 
    public static List<Pregunta> _preguntas {get; private set;} = new List<Pregunta>();
    public static List<Respuesta> _respuestas {get; private set;} = new List<Respuesta>();
    public static void InicializarJuego() {
        _username = "";
        dificultad = 1;
        categoria = 1;
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }
    public static List<Categoria> ObtenerCategorias() {
        return BD.ObtenerCategorias();
    }
    public static List<Dificultad> ObtenerDificultades() {
        return BD.ObtenerDificultades();
    }
    public static void CargarPartida(string username, int dificultad, int categoria) {
        _username = username;
        _preguntas = BD.ObtenerPreguntas(dificultad,categoria);
        _respuestas = BD.ObtenerRespuestas(_preguntas);
    }
    public static Pregunta ObtenerProximaPregunta() {
        if(_preguntas.Count != 0) {
            Random random = new Random();
            int numeroAleatorio = random.Next(0, _preguntas.Count);
            return _preguntas[numeroAleatorio];
        } else {
            return null;
        }

    }
    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta) {
        List<Respuesta> respuestas = BD.ObtenerRespuestas(_preguntas);
        List<Respuesta> respuesta = new List<Respuesta>();
        foreach (var item in respuestas)
        {
            if (item.IdPregunta == idPregunta) {
                respuesta.Add(item);
            }
        }
        return respuesta;
    }
    public static bool VerificarRespuesta(int idPregunta, int idRespuesta) {
        Pregunta pregunta = null;
        foreach (var item in _preguntas)
        {   
            if (item.IdPregunta == idPregunta) {
                pregunta = item;
            }
        }
        foreach (var item in _respuestas)
        {
            if (item.IdPregunta == idPregunta) {
                if(item.Opcion == idRespuesta && item.Correcta == true) {
                    _puntajeActual+=10;
                    _cantidadPreguntasCorrectas+=1;
                    _preguntas.Remove(pregunta);
                    _respuestas.Remove(item);
                    return true;
                }
            }
        }
        return false;
    }

}