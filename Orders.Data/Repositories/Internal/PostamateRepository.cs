using Orders.Data.Model;
using Orders.Data.Repositories.Abstract;

namespace Orders.Data.Repositories.Internal
{
	internal class PostamateRepository : Repository<Postamate>, IPostamateRepository
	{
		public PostamateRepository(DataContext context) : base(context)
		{
		}

		public Postamate Get(string number)
		{
			return Entities.Find(number);
		}
		public bool IsAvailable(string number)
		{
			return Entities.Find(number).Status;
		}
	}
}
