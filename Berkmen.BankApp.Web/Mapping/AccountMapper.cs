using Berkmen.BankApp.Web.Data.Entities;
using Berkmen.BankApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkmen.BankApp.Web.Mapping
{
	public class AccountMapper :IAccountMapper
	{
		public Account MapToAccountCreateModel(AccountCreateModel model)
		{
			return new Account
			{
				AccountNumber = model.AccountNumber,
				ApplicationUserId = model.ApplicationUserId,
				Balance = model.Balance,
				
				
			};
		}

	}
}
