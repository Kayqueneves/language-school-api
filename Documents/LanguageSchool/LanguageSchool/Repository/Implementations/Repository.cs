using LanguageSchool.Repository.Interfaces;
using LanguageSchool.Data;
using Microsoft.EntityFrameworkCore;

namespace LanguageSchool.Repository.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        this._context = context;
    }
    public async Task<T> CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        _context.Set<T>().Remove(await _context.Set<T>().FindAsync(id));
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }


    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> UpdateAsync(int id, T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    

}
