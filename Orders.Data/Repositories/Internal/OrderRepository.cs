using System.IO;
using System.Text.RegularExpressions;
using Orders.Data.Model;
using Orders.Data.Repositories.Abstract;

namespace Orders.Data.Repositories.Internal
{
	internal class OrderRepository : Repository<Order>, IOrderRepository
	{
		//Проверяет на соответствие маске «+7XXX-XXX-XX-XX»,
		const string PhoneRegex = @"[+][7]\d{3}[-]\d{3}[-]\d{2}[-]\d{2}";
		public OrderRepository(DataContext context) : base(context)
		{
		}

		public new void Add(Order order)
		{
			var isPhoneCorrect =  Regex.IsMatch(order.PhoneNumber, PhoneRegex);
			if (!isPhoneCorrect)
				throw new InvalidDataException("Номер телефона был введён в не верном формате");
			Entities.Add(order);
		}
	}
}
