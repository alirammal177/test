using System.Threading;
using System.Threading.Tasks;

namespace QAInsight.Application.Common;

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}