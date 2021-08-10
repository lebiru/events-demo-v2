using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace events_demo_v2.Handlers.Products
{
    public class CreatedFileSucceededNotificationHandler : INotificationHandler<CreatedFileSucceededNotification>
    {
        public Task Handle(CreatedFileSucceededNotification notification, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("File Created Successfully");
            return Task.CompletedTask;
        }
    }
}
