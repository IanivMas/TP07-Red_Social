namespace TP07.Models;
public class Publicacion
{
    public int Id {get; set;}
    public int IdUsuario {get; set;}
    public string Titulo {get; set;}
    public string Descripcion {get; set;}
    public string Imagen {get; set;}
    public DateTime FechaPublicacion {get; set;}
    public Publicacion(int id, int idUsuario, string titulo, string descripcion, string imagen, DateTime fechaPublicacion)
    {
        this.Id = id;
        this.IdUsuario = idUsuario;
        this.Titulo = titulo;
        this.Descripcion = descripcion;
        this.Imagen = imagen;
        this.FechaPublicacion = fechaPublicacion;
    }
    public Publicacion()
    {


    }
}