using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
public static class BD {
    private static string _connectionString = @"Server=localhost;DataBase=PreguntadOrt;Trusted_Connection=True;";
    public static void ObtenerCategorias() {
        List<Categoria> categorias = null;
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sp = "ObtenerCategorias";
            categorias = db.Query<Categoria>(sp, new {}, commandType: CommandType.StoredProcedure).ToList();
        }
        return categorias;
    }
    public static void ObtenerDificultades(){

    }
    public static ObtenerPreguntas(int dificultad, int categoria) {

    }
    public static ObtenerRespuestas(List<Pregunta> preguntas) {
        
    }
}