public static class Respuesta {
    public int IdRespuestas { set;  get;}
    public int IdPregunta { set;  get;}
    public int Opcion { set;  get;}
    public string Contenido { set;  get;}
    public bool Correcta { set;  get;}
    public string Foto { set;  get;}
    public Respuesta(int IdRespuestas, int IdPregunta, int Opcion, string Contenido, bool Correcta, string Foto ) {
        IdRespuestas = IdRespuestas;
        IdPregunta = IdPregunta;
        Opcion = Opcion;
        Contenido = Contenido;
        Correcta = Correcta;
        Foto = Foto;
    }
}