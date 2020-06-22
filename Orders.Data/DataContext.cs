using System;
using Microsoft.EntityFrameworkCore;
using Orders.Data.Model;
using Orders.Data.TestData;

namespace Orders.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Order> Orders { get; set; }

		public DbSet<Postamate> Postamates { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			Seed(modelBuilder);
			base.OnModelCreating(modelBuilder);
		}



		private void Seed(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Postamate>().HasData(TestDataModels.Postamates.PostamateOne);
			modelBuilder.Entity<Postamate>().HasData(TestDataModels.Postamates.PostamateTwo);

			modelBuilder.Entity<Order>().HasData(TestDataModels.Orders.OrderOne);

		}
		
		//Нужно для использования миграций
		public void PopulateTestData()
		{

			TestDataModels.Postamates.PostamateOne = Postamates.Add(TestDataModels.Postamates.PostamateOne).Entity;
			TestDataModels.Postamates.PostamateTwo = Postamates.Add(TestDataModels.Postamates.PostamateTwo).Entity;
			SaveChanges();

			TestDataModels.Orders.OrderOne = Orders.Add(TestDataModels.Orders.OrderOne).Entity;
			SaveChanges();

		}

	}
}
