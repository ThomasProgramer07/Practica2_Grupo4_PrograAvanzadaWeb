using Microsoft.AspNetCore.Mvc;
using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Services.Producto;

namespace Practica2_Grupo4_PrograAvanzadaWeb.Controllers;

public class ProductoController : Controller
{
    private readonly IProductoServicio _productoServicio;

    public ProductoController(IProductoServicio productoServicio)
    {
        _productoServicio = productoServicio;
    }

    public async Task<IActionResult> Index()
    {
        var respuesta = await _productoServicio.GetProductos();
        return View(respuesta.Datos);
    }

}