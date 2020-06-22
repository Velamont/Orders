using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Orders.Data.Repositories.Abstract
{
	public interface IRepository<TEntity> where TEntity : class
	{
		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);
		void Update(TEntity entity);
		void UpdateRange(IEnumerable<TEntity> entities);
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);

		IEnumerable<TEntity> GetAll();
		TEntity Get(int number);
		TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty);
	}
}
