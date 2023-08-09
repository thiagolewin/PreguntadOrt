public static class Pregunta {
    public int IdPregunta { set;  get;}
    public int IdCategoria { set;  get;}
    public int IdDificultad { set;  get;}
    public string Enunciado { set;  get;}
    public string Foto { set;  get;}
    public Pregunta(int IdPregunta, int IdCategoria, int IdDificultad, string Enunciado, string Foto) {
        IdPregunta = IdPregunta;
        IdCategoria = IdCategoria;
        IdDificultad = IdDificultad;
        Enunciado = Enunciado;
        Foto = Foto;
    }
}