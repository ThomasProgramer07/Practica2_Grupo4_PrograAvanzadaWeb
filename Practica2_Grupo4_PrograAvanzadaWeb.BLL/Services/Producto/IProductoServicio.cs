using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;

namespace Practica2_Grupo4_PrograAvanzadaWeb.BLL.Services.Producto;

public interface IProductoServicio
{
    Task<Respuesta<List<ProductoDto>>> GetProductos();
    Task<Respuesta<ProductoDto?>> GetProductoById(int id);

}