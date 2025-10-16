using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DeparmentModel;
using Demo.DAL.Models.Shared;
using Demo.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _context) :IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        //Get All TEntity 
        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (WithTracking) return _context.Set<TEntity>().Where(entity=>entity.IsDeleted==false).ToList();
            else return _context.Set<TEntity>().Where(entity => entity.IsDeleted == false).AsNoTracking();

        }
        public TEntity? GetById(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            return entity;

        }
        //Add TEntity 
        public int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }
        //Update TEntity 
        public int Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges();
        }
        //Delete TEntity 
        public int Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();

        }



        

    }
}
