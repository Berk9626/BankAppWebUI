using Berkmen.BankApp.Web.Data.Interfaces;

namespace Berkmen.BankApp.Web.Data.UnitOfWork
{
	public interface IUow
	{
		IRepository<T> GetRepository<T>() where T : class, new();
		void SaveChanges();
	}
}