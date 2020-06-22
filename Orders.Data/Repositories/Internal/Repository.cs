using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Orders.Data.Repositories.Abstract;

namespace Orders.Data.Repositories.Internal
{
	internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{

		protected readonly DbSet<TEntity> Entities;
		protected readonly DataContext Context;

		public Repository(DataContext context)
		{
			Entities = context.Set<TEntity>();
			Context = context;
		}

		public void Add(TEntity entity)
		{
			Entities.Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			Entities.AddRange(entities);
		}

		public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
		{
			return Entities.Where(predicate);
		}

		public IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
		{
			return Entities.Include(navigationProperty);
		}

		public TEntity Get(int number)
		{
			return Entities.Find(number);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return Entities.ToList();
		}

		public TEntity GetSingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
		{
			return Entities.SingleOrDefault(predicate);
		}

		public virtual void Remove(TEntity entity)
		{
			Entities.Remove(entity);
		}

		public virtual void RemoveRange(IEnumerable<TEntity> entities)
		{
			Entities.RemoveRange(entities);
		}

		public virtual void Update(TEntity entity)
		{
			Entities.Update(entity);
		}

		public virtual void UpdateRange(IEnumerable<TEntity> entities)
		{
			Entities.UpdateRange(entities);
		}
	}
}
