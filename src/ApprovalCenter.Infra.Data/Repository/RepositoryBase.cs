using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalCenter.Domain.Core.Interfaces.Repository;
using ApprovalCenter.Infra.Data.Context;

namespace ApprovalCenter.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ApprovalCenterContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(ApprovalCenterContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRanger(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Attach(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void AttachRanger(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
