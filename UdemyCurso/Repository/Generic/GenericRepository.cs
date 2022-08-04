using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;

namespace UdemyCurso.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MySQLContext context;
        private DbSet<T> dataset;
        public GenericRepository(MySQLContext context)
        {
            this.context = context;
            this.dataset = context.Set<T>();
        }

        public List<T> FindAll()
        {
            return this.dataset.ToList();
        }
        public T FindById(long id)
        {
            return this.dataset.SingleOrDefault(item => item.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                this.dataset.Add(item);
                this.context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T T)
        {
            bool exists = this.dataset.Any(p => p.Id.Equals(T.Id));
            if (!exists) return null;

            var result = this.dataset.SingleOrDefault(p => p.Id.Equals(T.Id));
            if (result != null)
            {
                try
                {
                    this.context.Entry(result).CurrentValues.SetValues(T);
                    this.context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public void Delete(long id)
        {
            var result = this.dataset.SingleOrDefault(item => item.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    this.context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return this.dataset.Any(p => p.Id.Equals(id));
        }
    }
}