using Berkmen.BankApp.Web.Data.Context;
using Berkmen.BankApp.Web.Data.Interfaces;
using Berkmen.BankApp.Web.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkmen.BankApp.Web.Data.UnitOfWork
{//bunu yapma sebebimiz SendMoney kısmında işlemlerin tek bir databasemiş gibi algılanması ve herhangi bir hatada işlemin iptali için. Ek olarakta SaveChanges'ı ayırmalıyız.
	public class Uow: IUow
	{
		private readonly BankContext _context;

		public Uow(BankContext context)
		{
			_context = context;
		}

		public IRepository<T> GetRepository<T>() where T: class, new()
		{
			return new Repository<T>(_context); //BU repository T için olacak ve context örneğini kullanacak. İlgili repository'nin tek bir context ile, ilgili requeste çalışmasını sağladık.

		}

		public void SaveChanges() //repositorydeki bütün SaveChangesları kaldırdım. Artık burdan yöneteceğim.
		{
			_context.SaveChanges();

		}



	}
}
