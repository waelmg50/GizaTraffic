using System.Linq.Expressions;

namespace GizaTraffic.Repositories.SortingAndPagination
{
    public class SortColumn<T>
    {
        public Expression<Func<T, object>> Expression { get; set; } = default!;

        public bool Ascending { get; set; } = true;
    }
}
