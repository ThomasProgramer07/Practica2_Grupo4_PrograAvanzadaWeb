using Microsoft.EntityFrameworkCore;
using Practica2_Grupo4_PrograAvanzadaWeb.DAL.Data;

namespace Practica2_Grupo4_PrograAvanzadaWeb.DAL.Repositorios.Producto;

public class ProductoRepositorio : RepositorioGenerico<Entidades.Producto>, IProductoRepositorio
{
    public ProductoRepositorio(ApplicationDbContext context) : base(context) { }

    // Include para traer el nombre de la categoría en el listado
    public async Task<List<Entidades.Producto>> GetProductos()
        => await _dbSet.AsNoTracking()
                       .Include(p => p.FkCategoriaNavigation)
                       .ToListAsync();
}