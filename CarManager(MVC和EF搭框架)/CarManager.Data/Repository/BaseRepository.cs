using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CarManager.Data.IRepository;

namespace CarManager.Data.Repository
{
    /// <summary>
    /// IBase仓储的实现类
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IDbContext _dbContext;
        private IDbSet<T> _dbset;


        public BaseRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        protected virtual IDbSet<T> Dbset
        {
            get { return this._dbset = this._dbset ?? _dbContext.Set<T>(); }
        }
        
        public bool Delete(Expression<Func<T, bool>> expression)
        {
            var query = _dbContext.Set<T>().AsQueryable().Where(expression).FirstOrDefault();
            if (query==null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            this.Dbset.Remove(query);
            return _dbContext.SaveChanges()>0 ? true : false;
        }

        public List<T> Get()
        {
            return this.Dbset.ToList();
        }

        public T GetById(object id)
        {
            return this.Dbset.Find(id);
        }

        public T Insert(T entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var obj=this.Dbset.Add(entity);
            if (_dbContext.SaveChanges()>0)
            {
                return obj;
            }
            return null;
        }

        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return _dbContext.SaveChanges();
        }
    }
}
