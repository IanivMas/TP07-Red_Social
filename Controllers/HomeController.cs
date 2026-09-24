using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using TP07.Models;

namespace TP07.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

        public IActionResult Registro()
{
    return View();
}

public IActionResult InicioSesion()
{
    return View();
}

[HttpPost]
public IActionResult Registro(string NombreUsuario, int Id, string Contraseña, string Nombre, string Apellido)
{
    BD bd = new BD();
    Usuario u = new Usuario(Nombre, Apellido, NombreUsuario, Contraseña,Id);
    if (bd.buscarPorNombreUsuario(u.NombreUsuario) == null)
    {
       bd.agregarUsuario(u);
        return RedirectToAction("InicioSesion", "Home");
    }
    else
    {
        ViewBag.error = "El nombre de usuario ya existe.";
         return RedirectToAction("Registro", "Home");
    }
    
}
    [HttpPost]
public IActionResult InicioSesion(string NombreUsuario, string Contraseña)
{
    BD bd = new BD();
    Usuario usuarioEncontrado = bd.encontrarUsuario(NombreUsuario, Contraseña);
    if (usuarioEncontrado == null)
    {
        ViewBag.Error = "Usuario o contraseña incorrectos.";
        return View();
    }
    HttpContext.Session.SetString("NombreUsuario", usuarioEncontrado.NombreUsuario);
     HttpContext.Session.SetString("Contraseña", usuarioEncontrado.Contraseña);

   
    return RedirectToAction("PaginaPrincipal", "Home");
}

    public IActionResult PaginaPrincipal()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("NombreUsuario")))
        {
            
            return RedirectToAction("InicioSesion", "Home");
        }
        ViewBag.NombreUsuario = HttpContext.Session.GetString("NombreUsuario");
        ViewBag.Contraseña = HttpContext.Session.GetString("Contraseña");
        ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
        ViewBag.Apellido = HttpContext.Session.GetString("Apellido");

        return View();
        
    }
    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("InicioSesion", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
