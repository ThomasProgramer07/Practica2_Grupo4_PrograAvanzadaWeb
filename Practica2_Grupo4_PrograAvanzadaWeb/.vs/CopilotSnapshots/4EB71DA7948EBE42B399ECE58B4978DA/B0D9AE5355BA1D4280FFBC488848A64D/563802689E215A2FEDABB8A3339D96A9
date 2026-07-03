using Practica2_Grupo4_PrograAvanzadaWeb.DAL.Data;

namespace Practica2_Grupo4_PrograAvanzadaWeb.DAL.Repositorios.Categoria;

public class CategoriaRepositorio : RepositorioGenerico<Entidades.Categoria>, ICategoriaRepositorio
{
    public CategoriaRepositorio(ApplicationDbContext context) : base(context) { }

    public async Task<List<Entidades.Categoria>> GetCategorias()
        => await GetAll();
}