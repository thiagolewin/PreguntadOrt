public static class Categoria {
    public int IdCategoria { set;  get;}
    public string Nombre { set;  get;}
    public string Foto { set;  get;}
    public Categoria(int IdCategoria, string Nombre, string Foto ) {
        IdCategoria = IdCategoria;
        Nombre = Nombre;
        Foto = Foto;
    }
}