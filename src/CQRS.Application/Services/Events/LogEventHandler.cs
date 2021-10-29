﻿using CQRS.Application.Services.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Services.Events
{
    public class LogEventHandler :
                 INotificationHandler<CustomerActionNotification>,
                 INotificationHandler<ErrorNotification>
    {
        public Task Handle(CustomerActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Customer {notification.Name} - {notification.Email} was {notification.Action.ToString().ToLower()} successfuly");
            });
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERROR : '{notification.Error} \n {notification.Stack}'");
            });
        }
    }
}
