using System;
using System.Collections.Generic;
using System.Text;
using Orders.Data.Model;
using Orders.Data.Model.Enums;

namespace Orders.Data.TestData
{
	public static class TestDataModels
	{
		private static readonly List<string> Products = new List<string>()
		{
			"Телевизор", "Компьютер", "Смартфон"
		};


		public static class Postamates
		{
			public static Postamate PostamateOne = new Postamate()
			{
				Address = "Улица Пушкина 17, кв 40",
				Number = "AE-340-BP",
				Status = true
			};

			public static Postamate PostamateTwo = new Postamate()
			{
				Address = "Улица Гагарина 40, кв 13",
				Number = "AE-240-DT",
				Status = false
			};
		}

		public static class Orders
		{
			public static Order OrderOne = new Order()
			{
				Number = 1,
				PostamateNumber = "AE-340-BP",
				PhoneNumber = "+7535-575-75-75",
				Price = 2000,
				Products = new List<string>{Products[0], Products[1], Products[2]},
				RecipientFullname = "Иванов Иван Иваныч",
				Status = Status.Registered
			};
		}

	}
}
