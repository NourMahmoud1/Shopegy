using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces;

public interface IRepository<T> where T : class
{
	List<T> GetAll(string? include = null);

    Task<List<T>> GetAllAsync(string? include = null);
	T GetById(int id);
	Task<T> GetByIdAsync(int id);
	void Add(T entity);
	Task AddAsync(T entity);
	void Update(T entity);
	void Delete(T entity);


}
