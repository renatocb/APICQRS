﻿using MediatR;

namespace CQRS.Application.Services.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Error { get; set; }
        public string Stack { get; set; }
    }
}
