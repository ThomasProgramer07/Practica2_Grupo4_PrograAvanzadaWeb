using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;
using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Services.Categoria;
using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Services.Producto;

namespace Practica2_Grupo4_PrograAvanzadaWeb.Controllers;

public class ProductoController : Controller
{
    private readonly IProductoServicio _productoServicio;
    private readonly ICategoriaServicio _categoriaServicio; 

    public ProductoController(IProductoServicio productoServicio, ICategoriaServicio categoriaServicio)
    {
        _productoServicio = productoServicio;
        _categoriaServicio = categoriaServicio;
    }

    public async Task<IActionResult> Index()
    {
        var respuesta = await _productoServicio.GetProductos();
        var respuestaCategorias = await _categoriaServicio.GetCategorias();
        ViewBag.Categorias = new SelectList(respuestaCategorias.Datos ?? new List<CategoriaDto>(), "Id", "Nombre");

        return View(respuesta.Datos ?? new List<ProductoDto>());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProducto(ProductoDto producto)
    {
        if (!ModelState.IsValid)
        {
            var respuestaCategorias = await _categoriaServicio.GetCategorias();
            ViewBag.Categorias = new SelectList(respuestaCategorias.Datos ?? new List<CategoriaDto>(), "Id", "Nombre");
            return BadRequest(ModelState);
        }

        var respuesta = await _productoServicio.CreateProducto(producto);
        if (!respuesta.Exito)
        {
            TempData["Error"] = respuesta.Mensaje;
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }
}