using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DeparmentModel;
using Demo.DAL.Models.Shared;
using Demo.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _context) :IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        //Get All TEntity 
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking) return _context.Set<TEntity>()
                                             .Where(entity=>entity.IsDeleted==false)
                                             .ToList();

            else return _context.Set<TEntity>()
                                .Where(entity => entity.IsDeleted == false)
                                .AsNoTracking();

        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>()
                            .Where(predicate)
                            .ToList();
        }
        public TEntity? GetById(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            return entity;

        }
        //Add TEntity 
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
           
        }
        //Update TEntity 
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
           
        }
        //Delete TEntity 
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
          

        }

       
    }
}
