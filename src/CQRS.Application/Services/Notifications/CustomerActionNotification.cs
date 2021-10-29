using MediatR;

namespace CQRS.Application.Services.Notifications
{
    public class CustomerActionNotification : INotification
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ActionNotification Action { get; set; }
    }
}
