using marmeladka.core.entities;
using System;
using System.Data.Entity;

namespace marmeladka.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly marmeladkaDBEntities1 _marmDb;
        protected DbSet<T> DbSet;

        public BaseRepository(marmeladkaDBEntities1 db)
        {
            _marmDb = db;
            DbSet = db.Set<T>();
        }
        public void Savechanges()
        {
            _marmDb.SaveChanges();
        }

        public virtual T Delete(Guid id)
        {
            var entity = DbSet.Find(id);
            return entity != null ? DbSet.Remove(entity) : null;
        }

        public virtual void Add(T t)
        {
            DbSet.Add(t);
        }
        public virtual void Update(T t)
        {
            _marmDb.Entry(t).State = EntityState.Modified;
        }
    }
}