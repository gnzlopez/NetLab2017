using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T>

    where T : class
    {
        private DBContext context;

        public Repository()
        {
            context = new DBContext();
        }

        public T Persist(T entity)
        {
            return context.Set<T>().Add(entity);
        }

        public T Remove(T entity)
        {
            return context.Set<T>().Remove(entity);
        }

        public T Update(T entity)
        {
            context.Entry<T>(entity);
            return entity;
        }

        public IQueryable<T> Set()
        {
            return context.Set<T>();
        }

        public bool SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

