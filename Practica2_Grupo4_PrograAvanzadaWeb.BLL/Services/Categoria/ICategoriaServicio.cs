using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;

namespace Practica2_Grupo4_PrograAvanzadaWeb.BLL.Services.Categoria;

public interface ICategoriaServicio
{
    Task<Respuesta<List<CategoriaDto>>> GetCategorias();
    Task<Respuesta<CategoriaDto?>> GetCategoriaById(int id);

    Task<Respuesta<CategoriaDto>> CreateCategoria(CategoriaDto categoria);
    Task<Respuesta<CategoriaDto>> UpdateCategoria(CategoriaDto categoria);
    Task<Respuesta<CategoriaDto>> DeleteCategoria(int id);


}