using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orders.Data.Repositories;

namespace Orders.Data.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static void AddDatabase(this IServiceCollection services, string connectionString)
		{
            //Postgres не поддерживает MARS.
            //https://stackoverflow.com/questions/39595968/entityframework-dbcontext-lifecycle-postgres-an-operation-is-already-in-prog/39599923#39599923
			services.AddDbContext<DataContext>(x => 
				x.UseNpgsql(connectionString)
					.EnableSensitiveDataLogging(), 
				ServiceLifetime.Transient);
		}

		public static void RepositoryRegister(this IServiceCollection services)
		{
			services.AddTransient<IUnitOfWork, UnitOfWork>();
		}
	}
}
