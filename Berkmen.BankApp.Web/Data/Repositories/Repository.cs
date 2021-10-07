
using Berkmen.BankApp.Web.Data.Context;
using Berkmen.BankApp.Web.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Berkmen.BankApp.Web.Data.Repositories
{
	public class Repository<T>  : IRepository<T>  where T : class, new() //t bir klas olmalı ve newlenebilmeli
	{
		private readonly BankContext _context;

		public Repository(BankContext context)
		{
			_context = context;
		}

		//IQuarable olması => db tarafında işi bitmemiş where, find 
		public void Create(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public List<T> GetAll()
		{
			return _context.Set<T>().ToList();
			
		}

		public T GetById(object id)
		{
			return _context.Set<T>().Find(id);
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}

		public IQueryable<T> GetQuaryable() //İLGİLİ DATAM QUARYABLE OLARAK GELECEK VE BUNUN ÜSTÜNDEN HAREKET EDEBİLECEĞİM
		{
			return _context.Set<T>().AsQueryable();
		}
	}
}
