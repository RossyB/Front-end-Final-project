﻿namespace BookStore.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using BookStore.Models;

    public interface IBookStoreDbContext
    {
        IDbSet<User> Users { get; set; }
            
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
