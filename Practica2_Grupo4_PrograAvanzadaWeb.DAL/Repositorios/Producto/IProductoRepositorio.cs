namespace Practica2_Grupo4_PrograAvanzadaWeb.DAL.Repositorios.Producto;

public interface IProductoRepositorio : IRepositorioGenerico<Entidades.Producto>
{
    Task<List<Entidades.Producto>> GetProductos();
}