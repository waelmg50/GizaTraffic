using GizaTraffic.DBContext;
using GizaTraffic.Models;
using GizaTraffic.Repositories.SortingAndPagination;
using GizaTraffic.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace GizaTraffic.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {

        #region Members

        protected GizaTrafficDBContext _context;

        #endregion

        #region Constructor

        public Repository(GizaTrafficDBContext? Context)
        {
            if (Context == null)
                _context = new DataContextFactory().CreateDbContext(Array.Empty<string>());
            else
                _context = Context;
        }

        #endregion

        #region Select Methods

        public virtual async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().AnyAsync(predicate);
        }
        public virtual async Task<T?> Get(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<PagedResult<T>> Get(IEnumerable<SortColumn<T>>? sort, int skip, int take)
        {
            return await Get(null, sort, skip, take);
        }
        public virtual async Task<PagedResult<T>> Get(Expression<Func<T, bool>>? predicate, IEnumerable<SortColumn<T>>? sortColumns, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                pageNumber = 1;

            if (pageSize < 1)
                pageSize = 50;

            IQueryable<T> query = _context.Set<T>()
                .AsNoTracking();

            // -------------------------
            // WHERE
            // -------------------------
            if (predicate != null)
                query = query.Where(predicate);

            // -------------------------
            // TOTAL COUNT
            // -------------------------
            int totalCount = await query.CountAsync();

            // -------------------------
            // ORDER BY
            // -------------------------
            if (sortColumns != null)
            {
                bool firstSort = true;

                foreach (var sortColumn in sortColumns)
                {
                    if (firstSort)
                    {
                        query = sortColumn.Ascending
                            ? query.OrderBy(sortColumn.Expression)
                            : query.OrderByDescending(sortColumn.Expression);

                        firstSort = false;
                    }
                    else
                    {
                        query = sortColumn.Ascending
                            ? ((IOrderedQueryable<T>)query)
                                .ThenBy(sortColumn.Expression)
                            : ((IOrderedQueryable<T>)query)
                                .ThenByDescending(sortColumn.Expression);
                    }
                }
            }

            // -------------------------
            // PAGINATION
            // -------------------------
            int skip = (pageNumber - 1) * pageSize;

            query = query
                .Skip(skip)
                .Take(pageSize);

            // -------------------------
            // EXECUTE
            // -------------------------
            var items = await query.ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetQuery(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<T?> GetOne(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().FirstAsync(predicate);
        }
        public virtual async Task<string> GetData(string sqlStatement, CommandType commandType, params SqlParameter[] parameters)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(await _context.Database.ExecuteQueryAsync(sqlStatement, commandType, parameters));
        }
        public virtual async Task<string> GetDataSet(string sqlStatement, CommandType commandType, params SqlParameter[] parameters)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(await _context.Database.ExecuteQueryAsync(sqlStatement, commandType, parameters));
        }
        public virtual string GetSqlData(string sqlStatement, CommandType commandType, params SqlParameter[] parameters)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(_context.Database.ExecuteQuery(sqlStatement, commandType, parameters));
        }
        public virtual async Task<int> ExecuteNoneQuery(string sqlStatement, CommandType commandType, params SqlParameter[] parameters)
        {
            return await _context.Database.ExecuteNoneQyeryAsync(sqlStatement, commandType, parameters);
        }

        #endregion

        #region Data Operations

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public virtual async Task AddRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }
        public virtual async Task Update(T NewEntity, object key)
        {
            var entity = await Get(key);
            if (entity == null)
                return;
            _context.Entry(entity).CurrentValues.SetValues(NewEntity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual async Task Remove(T entity)
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
        }
        public virtual async Task RemoveRange(IEnumerable<T> entities)
        {
            await Task.Run(() => _context.Set<T>().RemoveRange(entities));
        }

        #endregion

    }
}