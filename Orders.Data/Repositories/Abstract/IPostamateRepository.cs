using Orders.Data.Model;

namespace Orders.Data.Repositories.Abstract
{
	public interface IPostamateRepository : IRepository<Postamate>
	{
		Postamate Get(string number);
		bool IsAvailable(string number);
	}
}
