using Berkmen.BankApp.Web.Data.Context;
using Berkmen.BankApp.Web.Data.Entities;
using Berkmen.BankApp.Web.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkmen.BankApp.Web.Data.Repositories
{
	
	public class AccountRepository : IAccountUserRepository //135-2.63
	{
		private readonly BankContext _context;

		public AccountRepository(BankContext context)
		{
			_context = context;
		}

		public void Create(Account account)
		{
			_context.Set<Account>().Add(account);
			_context.SaveChanges();
		}
		public void Remove(Account account)
		{
			_context.Set<Account>().Remove(account);
			_context.SaveChanges();
		}

		public List<Account> GetAll()
		{
			return _context.Set<Account>().ToList();
		}

	}
}
