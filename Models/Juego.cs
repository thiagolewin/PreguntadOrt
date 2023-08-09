public static class Juego {
    public string _username {private set; get;}
    public int _puntajeActual {private set;get;}
    public int _cantidadPreguntasCorrectas {private set; get;}
    public List<Pregunta> _preguntas {private get; set;} = new List<Pregunta>;
    public List<Respuesta> _respuestas {private get; set;} = new List<Respuesta>;
    public static InicializarJuego() {
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }
    public static ObtenerCategorias() {
        return BD.ObtenerCategorias();
    }
    public static ObtenerDificultades() {
        return BD.ObtenerDificultades();
    }
    public static CargarPartida(string username, int dificultad, int categoria) {
        _preguntas = BD.ObtenerPreguntas(dificultad,categoria)
    }
    public static ObtenerProximaPregunta() {
        Random random = new Random();
        int numeroAleatorio = random.Next(0, _preguntas.Count);
        return _preguntas[numeroAleatorio]
    }
    public static ObtenerProximasRespuestas(int idPregunta) {
        List<Respuesta>[] respuestas = BD.ObtenerRespuestas(_preguntas);
        List<Respuesta> respuesta = new List<Respuesta>;
        foreach (var item in respuestas)
        {
            if (item[0].idPregunta == idPregunta) {
                respuesta = item;
            }
        }
    }
    public static bool VerificarRespuesta(int idPregunta, int idRespuesta) {
        List<Pregunta> pregunta = new List<Pregunta>;
        foreach (var item in _preguntas)
        {   
            if (item.idPregunta == idPregunta) {
                pregunta = item
            }
        }
        foreach (var item in _respuestas)
        {
            if (item.idPregunta == idPregunta) {
                if(item.Opcion == idRespuesta && item.Correcta == True) {
                    _puntajeActual+=10
                    _cantidadPreguntasCorrectas+=1
                    _preguntas.Remove(pregunta)
                    _respuestas.Remove(item)
                    return True;
                }
            }
        }
        return False;
    }

}