﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySafeNote.Core.Abstractions;
using MySafeNote.Core;
using Microsoft.EntityFrameworkCore;

namespace MySafeNote.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbContext Context { get; }
        protected DbSet<T> DbSet { get; }

        protected EfRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public async Task<int> CreateAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var item = await DbSet.FirstOrDefaultAsync(e => e.Id == id);
            DbSet.Remove(item);
            await SaveChanges();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await SaveChanges();
            return await DbSet.FirstOrDefaultAsync(e => e.Id == entity.Id);
        }

        private async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}