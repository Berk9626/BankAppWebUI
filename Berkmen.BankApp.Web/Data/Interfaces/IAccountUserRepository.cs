using Berkmen.BankApp.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkmen.BankApp.Web.Data.Interfaces
{
	public interface IAccountUserRepository
	{
		void Create(Account account);
	}
}
