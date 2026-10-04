namespace TP07.Models;
public class PublicacionMeGusta
{
    public int Id {get; set;}
    public int IdUsuario {get; set;}
    public int IdPublicacion {get; set;}
    public bool MeGusta {get; set;}
    public PublicacionMeGusta(int id, int idUsuario, int idPublicacion)
    {
        this.Id = id;
        this.IdUsuario = idUsuario;
        this.IdPublicacion = idPublicacion;
        this.MeGusta = false;
    }
    public PublicacionMeGusta()
    {

    }
}