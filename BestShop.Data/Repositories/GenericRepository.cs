namespace BestShop.Data.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
	private readonly BestShopContext _context;

	public GenericRepository(BestShopContext context)
	{
		_context = context;
	}

	#region Read
	public IQueryable<TEntity> GetEntity(
		Expression<Func<TEntity, bool>>? where = null,
		bool justActive = false,
		bool includeDeleted = false)

	{
		IQueryable<TEntity> query = _context.Set<TEntity>();
		if (where != null)
			query = query.Where(where);
		if (justActive)
			query = query.Where(a => a.IsActive);
		if (!includeDeleted)
			query = query.Where(a => !a.IsDeleted);
		return query;
	}

	public TEntity? GetById(object id)
	{
		try
		{
			var entity = _context.Set<TEntity>().Find(id);
			return entity;
		}
		catch (Exception)
		{
			return null;
		}

	}
	#endregion Read

	#region Create
	public TEntity Add(TEntity entity, bool saveNow = true)
	{
		entity.CreatedDate = DateTime.Now;
		entity.Guid = Guid.NewGuid();
		entity.IsDeleted= false;
		_context.Add(entity);
		if (saveNow)
			Save();
		return entity;
	}

	public List<TEntity> AddRange(List<TEntity> entities, bool saveNow = true)
	{
		entities.ForEach(a => a.CreatedDate = DateTime.Now);
		entities.ForEach(a => a.Guid = Guid.NewGuid());
		entities.ForEach(a => a.IsDeleted = false);


		_context.AddRange(entities);

		if (saveNow)
			Save();
		return entities;
	}

	#endregion Create

	#region Update

	public TEntity Update(TEntity entity, bool saveNow = true)
	{
		entity.LastModifiedDate = DateTime.Now;
		_context.Update(entity);
		if (saveNow)
			Save();
		return entity;
	}

	public List<TEntity> UpdateRange(List<TEntity> entities, bool saveNow = true)
	{
		entities.ForEach(a => a.LastModifiedDate = DateTime.Now);
		_context.UpdateRange(entities);
		if (saveNow)
			Save();
		return entities;
	}

	#endregion Update

	#region Delete

	public void Delete(TEntity entity, bool hardDelete = false, bool saveNow = true)
	{
		if (hardDelete)
			_context.Remove(entity);
		else
		{
			entity.IsDeleted = true;
			entity.LastModifiedDate = DateTime.Now;
			Update(entity, false);
		}

		if (saveNow)
			Save();
	}

	public void DeleteRange(List<TEntity> entities, bool hardDelete = false, bool saveNow = true)
	{
		if (hardDelete)
			_context.RemoveRange(entities);
		else
		{
			entities.ForEach(a => a.IsDeleted = true);
			entities.ForEach(a => a.LastModifiedDate = DateTime.Now);
			UpdateRange(entities, false);
		}
		if (saveNow)
			Save();
	}

	#endregion Delete

	#region Save

	public void Save()
	{
		_context.SaveChanges();
	}
	#endregion Save
}
