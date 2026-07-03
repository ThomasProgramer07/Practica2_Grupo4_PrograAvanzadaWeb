using AutoMapper;
using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;
using Practica2_Grupo4_PrograAvanzadaWeb.DAL.Repositorios.Categoria;

namespace Practica2_Grupo4_PrograAvanzadaWeb.BLL.Services.Categoria;

public class CategoriaServicio : ICategoriaServicio
{
    private readonly ICategoriaRepositorio _repositorio;
    private readonly IMapper _mapper;

    public CategoriaServicio(ICategoriaRepositorio repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<Respuesta<List<CategoriaDto>>> GetCategorias()
    {
        var categorias = await _repositorio.GetCategorias();
        return new Respuesta<List<CategoriaDto>>
        {
            Exito = true,
            Datos = _mapper.Map<List<CategoriaDto>>(categorias)
        };
    }

    public async Task<Respuesta<CategoriaDto?>> GetCategoriaById(int id)
    {
        var categoria = await _repositorio.GetById(id);
        if (categoria == null)
            return new Respuesta<CategoriaDto?> { Exito = false, Mensaje = "Categoría no encontrada" };

        return new Respuesta<CategoriaDto?> { Exito = true, Datos = _mapper.Map<CategoriaDto>(categoria) };
    }
}