namespace TP07.Models;
public class Comentario
{
    public int Id {get; set;}
    public int IdUsuarioComenta {get; set;}
    public int IdPublicacion {get; set;}
    public string Texto {get; set;}
    public DateTime FechaComentario {get; set;}
    public Comentario(int id, int idUsuarioComenta, int idPublicacion, string texto, DateTime fechaComentario)
    {
        this.Id = id;
        this.IdUsuarioComenta = idUsuarioComenta;
        this.IdPublicacion = idPublicacion;
        this.Texto = texto;
        this.FechaComentario = fechaComentario;
    }
    public Comentario()
    {

    }
}