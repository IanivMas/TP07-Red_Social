namespace TP07.Models;
using Microsoft.Data.SqlClient;
using Dapper;
public class BD
{
    private string conexion = @"Server=localhost;DataBase=TP05; Integrated Security=True; TrustServerCertificate=True;";
    public void agregarUsuario (Usuario u)
    {
        Console.WriteLine(u.NombreUsuario);
        string query = "INSERT INTO Usuarios (Nombre,Apellido,NombreUsuario,Contraseña,Id) VALUES (@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Id)";
        using (SqlConnection connection = new SqlConnection(conexion))
        {
            connection.Execute(query, new {nombre = u.Nombre, apellido = u.Apellido, usuario = u.NombreUsuario, clave = u.Contraseña, tipo = u.Id});
        }
    }

    public Usuario encontrarUsuario(string NombreUsuario, string Contraseña)
    {
        string query = "SELECT id, nombre, apellido, usuario, clave, tipo FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña";
        using (SqlConnection connection = new SqlConnection(conexion))
        {
            return connection.QueryFirstOrDefault<Usuario>(query, new { NombreUsuario = NombreUsuario, Contraseña = Contraseña });
        }
    }

    public Usuario buscarPorNombreUsuario(string NombreUsuario)
    {
        string query = "SELECT Nombre, apellido, NombreUsuario, Contraseña, Id FROM Usuarios WHERE NombreUsuario = @NombreUsuario";
        using (SqlConnection connection = new SqlConnection(conexion))
        {
            return connection.QueryFirstOrDefault<Usuario>(query, new { NombreUsuario = NombreUsuario });
        }
    }
    public void agregarPublicacion (Publicacion p)
    {
        string query = "INSERT INTO Publicaciones (IdUsuario, Titulo, Descripcion, Imagen, FechaPublicacion) VALUES (@IdUsuario, @Titulo, @Descripcion, @Imagen, @FechaPublicacion)";
        using (SqlConnection connection = new SqlConnection(conexion))
        {
            connection.Execute(query, new {IdUsuario = p.IdUsuario, Titulo = p.Titulo, Descripcion = p.Descripcion, Imagen = p.Imagen, FechaPublicacion = p.FechaPublicacion});
        }
    }
    public List<Publicacion> traerPublicaciones (int limite, DateTime reciente)
    {
        List<Publicacion> Publicaciones = new List<Publicacion>();
        using (SqlConnection connection = new SqlConnection (conexion))
        {
            string query = "SELECT TOP (@limite) * FROM Publicaciones WHERE FechaPublicacion <= @reciente ORDER BY FechaPublicacion DESC";
            Publicaciones = connection.Query<Publicacion>(query, new { limite = limite, reciente = reciente }).ToList();
        }
        return Publicaciones;
    }
    public void agregarComentario (Comentario c)
    {
        string query = "INSERT INTO Comentarios (IdUsuarioComenta, IdPublicacion, Texto, FechaComentario) VALUES (@IdUsuarioComenta, @IdPublicacion, @Texto, @FechaComentario)";
        using (SqlConnection connection = new SqlConnection(conexion))
        {
            connection.Execute(query, new {IdUsuarioComenta = c.IdUsuarioComenta, IdPublicacion = c.IdPublicacion, Texto = c.Texto, FechaComentario = c.FechaComentario});
        }
    }
    public List<Comentario> traerComentarios (int IdPublicacion)
    {
        List<Comentario> Comentarios = new List<Comentario>();
        using (SqlConnection connection = new SqlConnection (conexion))
        {
            string query = "SELECT * FROM Comentarios WHERE IdPublicacion";
            Comentarios = connection.Query<Comentario>(query).ToList();
        }
        return Comentarios;
    }
}