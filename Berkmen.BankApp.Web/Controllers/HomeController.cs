using Berkmen.BankApp.Web.Data.Context;
using Berkmen.BankApp.Web.Data.Entities;
using Berkmen.BankApp.Web.Data.Interfaces;
using Berkmen.BankApp.Web.Data.UnitOfWork;
using Berkmen.BankApp.Web.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Berkmen.BankApp.Web.Controllers
{
	public class HomeController : Controller
	{
		
		//private readonly IApplicationUserRepository _applicationUserRepository;
		private readonly IUserMapper _userMapper;
		private readonly IUow _uow;

	

		public HomeController(BankContext context,/* IApplicationUserRepository applicationUserRepository,*/ IUserMapper userMapper, IUow uow)
		{

			//_applicationUserRepository = applicationUserRepository;
			_uow = uow;
			_userMapper = userMapper;
		}

		public IActionResult Index()
		{
			return View(_userMapper.MapToListOfUserList( _uow.GetRepository<ApplicationUser>().GetAll())); 
		}
	}
}
