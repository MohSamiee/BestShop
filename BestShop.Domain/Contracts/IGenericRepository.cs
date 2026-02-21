using System.Linq.Expressions;
using BestShop.Domain.Models.Common;

namespace BestShop.Domain.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        #region Read
        IQueryable<TEntity> GetEntity(
            Expression<Func<TEntity, bool>>? where = null,
            bool justActive = false,
            bool includeDeleted = false
            );
        TEntity? GetById(object id);
        #endregion Read

        #region Create

        TEntity Add(TEntity entity, bool saveNow = false);
        List<TEntity> AddRange(List<TEntity> entities, bool saveNow = false);

		#endregion Create

		#region Update
		TEntity Update(TEntity entity, bool saveNow = false);
		List<TEntity> UpdateRange(List<TEntity> entities, bool saveNow = false);

		#endregion Update

		#region Delete
		void Delete(TEntity entity, bool hardDelete = false, bool saveNow = false);
        void DeleteRange(List<TEntity> entities, bool hardDelete = false, bool saveNow = false);

		#endregion Delete

		#region Save

		void Save();

        #endregion Save
    }
}
