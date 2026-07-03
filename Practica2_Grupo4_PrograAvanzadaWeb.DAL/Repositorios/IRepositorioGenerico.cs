using System.Linq.Expressions;

namespace Practica2_Grupo4_PrograAvanzadaWeb.DAL.Repositorios;

public interface IRepositorioGenerico<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task<T> Create(T entidad);
    Task<bool> Update(T entidad);
    Task<bool> Delete(int id);
    Task<bool> Exists(Expression<Func<T, bool>> predicado);
}