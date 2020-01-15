using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.Contracts.Services
{
    public interface IMediatorService
    {
        Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest<TResponse>;
        Task Notify<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification; 
    }
}
