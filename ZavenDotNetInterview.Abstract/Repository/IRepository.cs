using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ZaventDotNetInterview.Models;

namespace ZavenDotNetInterview.Abstract
{
    public interface IRepository<TEntity> where TEntity : BaseEntityModel
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        Guid Add(TEntity entity);
       
    } 
}
