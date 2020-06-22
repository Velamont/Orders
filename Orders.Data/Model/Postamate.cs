using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.Data.Model
{
	public class Postamate
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Number { get; set; }
		public string Address { get; set; }
		public bool Status { get; set; }
	}
}
