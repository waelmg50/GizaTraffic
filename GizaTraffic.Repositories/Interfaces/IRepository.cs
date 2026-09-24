using GizaTraffic.Models;
using GizaTraffic.Repositories.SortingAndPagination;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Linq.Expressions;

namespace GizaTraffic.Services.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {

        #region Select Methods

        Task<T?> Get(object id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task<PagedResult<T>> Get(IEnumerable<SortColumn<T>>? sort, int skip, int take);
        Task<IEnumerable<T>> GetQuery(Expression<Func<T, bool>> predicate);
        Task<PagedResult<T>> Get(Expression<Func<T, bool>>? predicate, IEnumerable<SortColumn<T>>? sortColumns, int pageNumber, int pageSize);
        Task<PagedResult<TResult>> Get<TResult>(Expression<Func<T, bool>>? predicate, Expression<Func<T, TResult>> selector, IEnumerable<SortColumn<T>>? sortColumns, int pageNumber, int pageSize);
        Task<T?> GetOne(Expression<Func<T, bool>> predicate);
        Task<string> GetData(string sqlStatement, CommandType commandType, params SqlParameter[] parameters);
        Task<string> GetDataSet(string sqlStatement, CommandType commandType, params SqlParameter[] parameters);
        string GetSqlData(string sqlStatement, CommandType commandType, params SqlParameter[] parameters);
        Task<int> ExecuteNoneQuery(string sqlStatement, CommandType commandType, params SqlParameter[] parameters);
        //Task<(User?, DateTime)> GetLastUpdateInfo(int ID);

        #endregion

        #region Data Operations

        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Update(T entity, object key);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);

        #endregion

    }
}