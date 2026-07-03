using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Practica2_Grupo4_PrograAvanzadaWeb.DAL.Data;

namespace Practica2_Grupo4_PrograAvanzadaWeb.DAL.Repositorios;

public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositorioGenerico(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<List<T>> GetAll()
        => await _dbSet.AsNoTracking().ToListAsync();

    public virtual async Task<T?> GetById(int id)
        => await _dbSet.FindAsync(id);

    public virtual async Task<T> Create(T entidad)
    {
        _dbSet.Add(entidad);
        await _context.SaveChangesAsync();
        return entidad;
    }

    public virtual async Task<bool> Update(T entidad)
    {
        _dbSet.Update(entidad);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> Delete(int id)
    {
        var entidad = await _dbSet.FindAsync(id);
        if (entidad == null) return false;
        _dbSet.Remove(entidad);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> Exists(Expression<Func<T, bool>> predicado)
        => await _dbSet.AnyAsync(predicado);
}