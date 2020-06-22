using Orders.Data.Repositories.Abstract;

namespace Orders.Data.Repositories
{
	public interface  IUnitOfWork
	{
		IOrderRepository OrderRepository { get; }
		IPostamateRepository PostamateRepository { get; }
		void Commit();
	}
}
