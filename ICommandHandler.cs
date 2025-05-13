using System.Threading;
using System.Threading.Tasks;

namespace QAInsight.Application.Common;

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}