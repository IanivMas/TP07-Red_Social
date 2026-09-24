namespace TP07.Models;
public class Usuario
{
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public string NombreUsuario {get; set;}
    public string Contraseña {get; set;}
    public int Id {get; set;}
    
    public Usuario (string Nombre, string Apellido, string NombreUsuario, string Contraseña, int Id)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.NombreUsuario = nombreUsuario;
        this.Contraseña = contraseña;
        this.Id = id;
    }
    public Usuario ()
    {

    }
}