using AutoMapper;
using Practica2_Grupo4_PrograAvanzadaWeb.BLL.Dtos;
using Practica2_Grupo4_PrograAvanzadaWeb.DAL.Repositorios.Producto;

namespace Practica2_Grupo4_PrograAvanzadaWeb.BLL.Services.Producto;

public class ProductoServicio : IProductoServicio
{
    private readonly IProductoRepositorio _repositorio;
    private readonly IMapper _mapper;

    public ProductoServicio(IProductoRepositorio repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<Respuesta<List<ProductoDto>>> GetProductos()
    {
        var productos = await _repositorio.GetProductos();
        return new Respuesta<List<ProductoDto>>
        {
            Exito = true,
            Datos = _mapper.Map<List<ProductoDto>>(productos)
        };
    }

    public async Task<Respuesta<ProductoDto?>> GetProductoById(int id)
    {
        var producto = await _repositorio.GetById(id);
        if (producto == null)
            return new Respuesta<ProductoDto?> { Exito = false, Mensaje = "Producto no encontrado" };

        return new Respuesta<ProductoDto?> { Exito = true, Datos = _mapper.Map<ProductoDto>(producto) };
    }

    public async Task<Respuesta<ProductoDto>> CreateProducto(ProductoDto productoDto)
    {
        if (productoDto == null)
        {
            return new Respuesta<ProductoDto>
            {
                Exito = false,
                Mensaje = "Producto inválido"
            };
        }

        var entity = _mapper.Map<DAL.Entidades.Producto>(productoDto);
        var creada = await _repositorio.Create(entity);

        return new Respuesta<ProductoDto>
        {
            Exito = true,
            Datos = _mapper.Map<ProductoDto>(creada)
        };
    }
}