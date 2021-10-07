using Berkmen.BankApp.Web.Data.Entities;
using Berkmen.BankApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkmen.BankApp.Web.Mapping
{
	interface IAccountMapper
	{
		Account MapToAccountCreateModel(AccountCreateModel model);
	}
}
