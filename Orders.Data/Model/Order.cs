using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Orders.Data.Model.Enums;

namespace Orders.Data.Model
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Number { get; set; }
		public Status Status { get; set; }
		public List<string> Products { get; set; }
		public decimal Price { get; set; }
		public string PostamateNumber { get; set; }
		public string PhoneNumber { get; set; }
		public string RecipientFullname { get; set; }

	}
}
