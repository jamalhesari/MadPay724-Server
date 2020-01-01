using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Repo.Infrastructure
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        #region ctor
        private readonly DbContext _db;
        private readonly DbSet<TEntity> _dbset;
        public Repository(DbContext db)
        {
            _db = db;
            _dbset = _db.Set<TEntity>();
        }
        #endregion

        #region normal
        public void Insert(TEntity entity)
        {
            _dbset.Add(entity);
        }
        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("There is no entity");
            _dbset.Update(entity);
        }
        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new ArgumentException("There is no entity");
            _dbset.Remove(entity);
        }
        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }
        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> query = _dbset.Where(where).AsEnumerable();
            foreach (TEntity item in query)
            {
                _dbset.Remove(item);
            }
        }
        public TEntity GetById(object id)
        {
            return _dbset.Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbset.AsEnumerable();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault();
        }
        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _dbset.AsEnumerable();
        }
        #endregion

        #region async
        public async Task InsertAsync(TEntity entity)
        {
           await _dbset.AddAsync(entity);
        }
        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbset.FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbset.Where(where).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Repository()
        {
            Dispose(false);
        }
        #endregion
    }
}
