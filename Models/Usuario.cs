namespace TP05.Models;
public class Usuario
{
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public string NombreUsuario {get; set;}
    public string Contraseña {get; set;}
    public int Id {get; set;}
    
    public Usuario (string Nombre, string Apellido, string NombreUsuario, string Contraseña, int Id)
    {
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.NombreUsuario = NombreUsuario;
        this.Contraseña = Contraseña;
        this.Id = Id;
    }
    public Usuario ()
    {

    }
}