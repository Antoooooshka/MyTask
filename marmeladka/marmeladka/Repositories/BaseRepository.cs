using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace marmeladka.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly marmeladkaDBEntities1 marmDb;
        protected DbSet<T> dbSet;

        public BaseRepository(marmeladkaDBEntities1 db)
        {
            marmDb = db;
            dbSet = db.Set<T>();
        }

        public void Savechanges()
        {
            marmDb.SaveChanges();
        }

        public virtual T Delete(Guid id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
                return dbSet.Remove(entity);
            return null;
        }

        public virtual void Add(T t)
        {
            dbSet.Add(t);
        }
        public virtual void Update(T t)
        {
            marmDb.Entry(t).State = EntityState.Modified;
            dbSet.Add(t);
        }
    }
}