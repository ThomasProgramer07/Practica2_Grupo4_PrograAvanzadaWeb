using AutoMapper;
using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;

namespace Practica2_Grupo4_PrograAvanzadaWeb.BLL;

public class MapeoClases : Profile
{
    public MapeoClases()
    {
        CreateMap<DAL.Entidades.Categoria, CategoriaDto>().ReverseMap();

        CreateMap<DAL.Entidades.Producto, ProductoDto>()
            .ForMember(d => d.NombreCategoria,
                o => o.MapFrom(s => s.FkCategoriaNavigation.Nombre))
            .ReverseMap()
            .ForMember(e => e.FkCategoriaNavigation, o => o.Ignore());
    }
}