using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace events_demo_v2.Handlers.Products
{
    public class CreatedFileFailedNotificationHandler : INotificationHandler<CreatedFileFailedNotification>
    {
        public Task Handle(CreatedFileFailedNotification notification, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("File Creation Failure!");
            return Task.CompletedTask;
        }
    }
}
