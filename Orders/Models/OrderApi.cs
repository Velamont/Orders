using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Orders.Data.Model;
using Orders.Data.Model.Enums;

namespace Orders.Models
{
	public class OrderApi
	{
		public OrderApi() { }

		public OrderApi(Order order)
		{
			Number = order.Number;
			Status = order.Status;
			Products = order.Products;
			Price = order.Price;
			PostamateNumber = order.PostamateNumber;
			PhoneNumber = order.PhoneNumber;
			RecipientFullname = order.RecipientFullname;
		}
		public int Number { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public Status Status { get; set; }
		public List<string> Products { get; set; }
		public decimal Price { get; set; }
		public string PostamateNumber { get; set; }
		public string PhoneNumber { get; set; }
		public string RecipientFullname { get; set; }

		public Order ToOrder()
		{
			return new Order()
			{
				Number = this.Number,
				Status = this.Status,
				Products = this.Products,
				Price = this.Price,
				PostamateNumber = this.PostamateNumber,
				PhoneNumber = this.PhoneNumber,
				RecipientFullname = this.RecipientFullname
			};
		}
	}
}
