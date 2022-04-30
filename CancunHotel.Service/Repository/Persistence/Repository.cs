using CancunHotel.DTO;
using CancunHotel.Models;
using CancunHotel.Models.Context;
using CancunHotel.Service.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Service.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        internal DbContext context;
        internal Context _db;
        internal DbSet<TEntity> dbset;
        public Repository(DbContext context) 
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
            _db = new Context();

        }


        //public DbSet<rooms> Get() => _db.rooms;

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null)
        {
            IQueryable<TEntity> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderby !=null)
            {
                return orderby(query).AsNoTracking().ToList();
            }
            else {
                return query.AsNoTracking().ToList();
            }
        }

        public virtual void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (context.Entry(entityToUpdate).State!=EntityState.Modified && context.Entry(entityToUpdate).State!=EntityState.Added)
            {
                dbset.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
        }


    }
}
