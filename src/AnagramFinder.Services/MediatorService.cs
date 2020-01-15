using AnagramFinder.Contracts.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.Services
{
    public class MediatorService : IMediatorService
    {
        private readonly IMediator _mediator;

        public async Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>
        {
            return await _mediator.Send(request, cancellationToken);
        }

        public async Task Notify<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            await _mediator.Publish(notification, cancellationToken);
        }

        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
