using Orders.Data.Repositories.Abstract;
using Orders.Data.Repositories.Internal;

namespace Orders.Data.Repositories
{
	internal class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext context;

		public UnitOfWork(DataContext context)
		{
			this.context = context;
			OrderRepository = new OrderRepository(context);
			PostamateRepository = new PostamateRepository(context);
		}

		public IOrderRepository OrderRepository { get; }
		public IPostamateRepository PostamateRepository { get; }

		public void Commit()
		{
			context.SaveChanges();
		}
	}
}
