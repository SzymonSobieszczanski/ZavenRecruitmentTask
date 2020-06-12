using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ZavenDotNetInterview.Abstract.Logic
{
    public interface ILogic<TEntity> where TEntity : class
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        Guid Add(TEntity entity);
    }
}
