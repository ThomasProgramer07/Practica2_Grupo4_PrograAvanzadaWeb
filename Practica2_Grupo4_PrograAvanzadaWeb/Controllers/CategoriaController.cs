using Microsoft.AspNetCore.Mvc;
using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Services.Categoria;

namespace Practica2_Grupo4_PrograAvanzadaWeb.Controllers;

public class CategoriaController : Controller
{
    private readonly ICategoriaServicio _categoriaServicio;

    public CategoriaController(ICategoriaServicio categoriaServicio)
    {
        _categoriaServicio = categoriaServicio;
    }

    public async Task<IActionResult> Index()
    {
        var respuesta = await _categoriaServicio.GetCategorias();
        return View(respuesta.Datos);
    }

    // Compañero 2: Create (GET + POST)
    // Compañero 3: Edit (GET + POST)
    // Compañero 4: Delete (GET + POST)
}