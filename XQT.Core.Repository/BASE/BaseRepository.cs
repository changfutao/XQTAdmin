﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.EntityFramework;

namespace XQT.Core.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly XQTContext _context;

        public BaseRepository(XQTContext xqtContext)
        {
            _context = xqtContext;
        }
        public XQTContext DbContext()
        {
            return _context;
        }
        public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var savedEntity = await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            if(autoSave)
            {
               await _context.SaveChangesAsync();
            }
            return entity;
        }


        public async Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entityArray = entities.ToArray();

            await _context.Set<TEntity>().AddRangeAsync(entityArray, cancellationToken);

            if (autoSave)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _context.Attach(entity);

            var updatedEntity = _context.Update(entity).Entity;

            if (autoSave)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }

            return updatedEntity;
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().UpdateRange(entities);

            if (autoSave)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Remove(entity);

            if (autoSave)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var dbSet = _context.Set<TEntity>();

            var entities = await dbSet
                .Where(predicate)
                .ToListAsync(cancellationToken);

            await DeleteManyAsync(entities, autoSave, cancellationToken);

            if (autoSave)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _context.RemoveRange(entities);

            if (autoSave)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _context.Set<TEntity>().Where(predicate).SingleOrDefaultAsync(cancellationToken);
        }
        /// <summary>
        /// 数据不存在会抛出异常
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(predicate, cancellationToken);

            if (entity == null)
            {
                throw new Exception(nameof(TEntity) + ": 数据不存在");
            }

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetPagedListAsync(int skipCount, int pageSize, string sorting,
            CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().OrderBy(sorting).Skip(skipCount).Take(pageSize).ToListAsync(cancellationToken);
        }

        public Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return _context.Set<TEntity>().LongCountAsync(cancellationToken);
        }

        public Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return _context.Set<TEntity>().Where(predicate).LongCountAsync(cancellationToken);
        }
    }
}
