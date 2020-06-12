using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZavenDotNetInterview.Abstract;
using ZaventDotNetInterview.Models;

namespace ZavenDotNetInterview.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntityModel
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }
        public virtual TEntity Get(Guid id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().OrderBy(t => t.CreatedAt).ToList();
        }
        public virtual Guid Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return entity.Id;
        }
    }
}
