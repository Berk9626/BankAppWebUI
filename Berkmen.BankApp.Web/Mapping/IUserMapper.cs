

using Berkmen.BankApp.Web.Data.Entities;
using Berkmen.BankApp.Web.Models;
using System.Collections.Generic;

namespace Berkmen.BankApp.Web.Mapping
{
	public interface IUserMapper
	{
		List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);
		UserListModel MaptoUserList(ApplicationUser user);
	}
}
