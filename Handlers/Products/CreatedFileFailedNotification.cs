using System;
using MediatR;

namespace events_demo_v2.Handlers.Products
{
    public class CreatedFileFailedNotification : INotification
    {
        public string Name { get; set; }
    }
}
