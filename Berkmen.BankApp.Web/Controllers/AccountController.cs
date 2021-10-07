using Berkmen.BankApp.Web.Data.Context;
using Berkmen.BankApp.Web.Data.Entities;
using Berkmen.BankApp.Web.Data.Interfaces;
using Berkmen.BankApp.Web.Data.Repositories;
using Berkmen.BankApp.Web.Data.UnitOfWork;
using Berkmen.BankApp.Web.Mapping;
using Berkmen.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berkmen.BankApp.Web.Controllers
{
	public class AccountController : Controller
	{

		//private readonly IApplicationUserRepository _applicationUserRepository;
		//private readonly IUserMapper _userMapper;
		//private readonly IAccountMapper _accountMapper;
		//private readonly IAccountUserRepository _accountUserRepository;


		//public AccountController(BankContext bankContext, IApplicationUserRepository applicationUserRepository, IUserMapper userMapper, IAccountUserRepository accountUserRepository)
		//{

		//	_applicationUserRepository = applicationUserRepository;
		//	_userMapper = userMapper;
		//	_accountUserRepository = accountUserRepository;
		//}

		//private readonly IRepository<Account> _accountRepository;
		//private readonly IRepository<ApplicationUser> _userRepository;

		//public AccountController(IRepository<Account> accountRepository, IRepository<ApplicationUser> userRepository)
		//{
		//	_accountRepository = accountRepository;
		//	_userRepository = userRepository;
		//}

		private readonly IUow _uow;

		public AccountController(IUow uow)
		{
			_uow = uow;
		}

		[HttpGet]
		public IActionResult Create(int id)
		{
			var userinfo = _uow.GetRepository<ApplicationUser>().GetById(id);

			return View(new UserListModel
			{
				Name = userinfo.Name,
				Surname = userinfo.Surname,
				Id = userinfo.Id
			}) ;
		}

		[HttpPost]
		public IActionResult Create(AccountCreateModel model)
		{


			_uow.GetRepository<Account>().Create(new Account { 
			 
			 AccountNumber = model.AccountNumber,
			 ApplicationUserId = model.ApplicationUserId,
			 Balance = model.Balance

			 });
			_uow.SaveChanges();

			return RedirectToAction("Index","Home");
		}

		[HttpGet]
		public IActionResult GetByUserId(int userid) //amacım gelen userid ile gelen veriyi çekmek
		{
			var query = _uow.GetRepository<Account>().GetQuaryable();
			var accounts = query.Where(x => x.ApplicationUserId == userid).ToList();

			var user = _uow.GetRepository<ApplicationUser>().GetById(userid);
			var list = new List<AccountListModel>();

			ViewBag.FullName = user.Name + " " + user.Surname;

			foreach (var account in accounts)
			{
				list.Add(new AccountListModel()
				{
					AccountNumber = account.AccountNumber,
					ApplicationUserId = account.ApplicationUserId,
					Balance = account.Balance,
					
					Id = account.Id
					


				});
			}

			return View(list);

		}

		[HttpGet] //bana gelen account hariç diğer accounları listeleyen bir yapı 
		public IActionResult SendMoney(int accountId)
		{
			var query = _uow.GetRepository<Account>().GetQuaryable();
			var accounts = query.Where(x => x.Id != accountId).ToList();
			

			var list = new List<AccountListModel>();
			ViewBag.SenderAccountId = accountId;

			foreach (var account in accounts)
			{
				list.Add(new AccountListModel
				{
					AccountNumber = account.AccountNumber,
					ApplicationUserId = account.ApplicationUserId,
					Balance = account.Balance,
					Id = account.Id

				});

			}

			

			return View(new SelectList(list,"Id","AccountNumber")); //valuefieldim yani değer olarak alınacak şey ilk tırnak, ve textfieldım var. Yani id'si ile iş yapacağım, AccountNumberı göstereceğim
		}

		[HttpPost]
		public IActionResult SendMoney(SendMoneyModel model)
		{
			//Unit of work design diye geçiyor.

			var senderAccount = _uow.GetRepository<Account>().GetById(model.SenderAccountId);
			senderAccount.Balance -= model.Amount;
			_uow.GetRepository<Account>().Update(senderAccount);

			var account = _uow.GetRepository<Account>().GetById(model.AccountId);
			account.Balance += model.Amount;
			_uow.GetRepository<Account>().Update(account);

			_uow.SaveChanges();

			return RedirectToAction("Index", "Home");


		}


	}
}
