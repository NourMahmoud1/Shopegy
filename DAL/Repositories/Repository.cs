using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace  Repositories;

public abstract class Repository<T> : IRepository<T> where T : class
{
    private readonly ShopegyAppContext _context;

    public Repository(ShopegyAppContext context)
    {
        _context = context;
    }

	public virtual List<T> GetAll(string? include = null)
	{
		if (include == null)  // from default or passed from a calling function
		{
			return _context.Set<T>().ToList();
		}
		return _context.Set<T>().Include(include).ToList();
	}
	public  async virtual Task<List<T>> GetAllAsync(string? include = null)
	{
		if (include == null)  // from default or passed from a calling function
		{
			return await _context.Set<T>().ToListAsync();
		}
		return await _context.Set<T>().Include(include).ToListAsync();
	}
//----------------------------
	public virtual T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
	public async virtual Task<T> GetByIdAsync(int id)
	{
		return await _context.Set<T>().FindAsync(id);
	}
	//---------------------------------
	public virtual void  Add(T entity)
    {
        _context.Set<T>().Add(entity);
        //_context.SaveChanges();
    }
	public async virtual Task AddAsync(T entity)
	{
		await _context.Set<T>().AddAsync(entity);
	}
	//---------------------------------
	public virtual  void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        //_context.SaveChanges();
    }

	//------------------------------------------

	public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        //_context.SaveChanges();
    }
	
}
