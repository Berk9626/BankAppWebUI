using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkmen.BankApp.Web.Models
{
	public class UserListModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
	}

	public class AccountListModel //accountla ilgili dataları tutacağım
	{
		public int Id { get; set; } //valuem Id, göndereceğim accountun'un idsi
		public decimal Balance { get; set; }
		public int AccountNumber { get; set; }//account numberı kullanıcıya göstereceğim, id si iş yapacağım değerim olacak.
		public int ApplicationUserId { get; set; }
		

	}
}
