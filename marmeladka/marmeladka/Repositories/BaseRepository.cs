using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

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

        public async Task SaveChangesAsync()
        {
            await _marmDb.SaveChangesAsync();
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

        protected virtual void UpdateRange(List<T> models)
        {
            for (int i = 0; i < models.Count; i++)
            {
                _marmDb.Entry(models[i]).State = EntityState.Modified;  
            }
                
        }

        protected void PerformTransaction(Action action)
        {
            using (var transaction = new TransactionScope())
            {
                action();
                Savechanges();
                transaction.Complete();
            }
        }
    }
}