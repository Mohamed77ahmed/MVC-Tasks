using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DeparmentModel;
using Demo.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
       
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity,bool>> predicate );
        
        TEntity? GetById(int id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
