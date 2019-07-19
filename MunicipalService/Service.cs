using FinalEntity;
using FinalRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalService
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        DataContext context = new DataContext();

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public int Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

    /*    public TEntity Get(string name)
        {
            return context.Set<TEntity>().;
        }
        */
        public int Update(TEntity entity)
        {
           // context.Entry<TEntity>(entity).State = EntityState.Modified;
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            //context.Set<TEntity>().Remove(entity);
            context.Entry<TEntity>(entity).State = EntityState.Deleted;
            return context.SaveChanges();
        }
}
}
