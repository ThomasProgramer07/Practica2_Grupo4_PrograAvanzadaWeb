using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;

namespace Practica2_Grupo4_PrograAvanzadaWeb.BLL.Services.Categoria;

public interface ICategoriaServicio
{
    Task<Respuesta<List<CategoriaDto>>> GetCategorias();
    Task<Respuesta<CategoriaDto?>> GetCategoriaById(int id);
    // agregar aquí CrearCategoria, UpdateCategoria, DeleteCategoria
}