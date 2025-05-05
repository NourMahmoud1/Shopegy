using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace  Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ShopegyAppContext _context;

    public Repository(ShopegyAppContext context)
    {
        _context = context;
    }

	public List<T> GetAll(string? include = null)
	{
		if (include == null)  // from default or passed from a calling function
		{
			return _context.Set<T>().ToList();
		}
		return _context.Set<T>().Include(include).ToList();
	}

	public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        //_context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        //_context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        //_context.SaveChanges();
    }
}
