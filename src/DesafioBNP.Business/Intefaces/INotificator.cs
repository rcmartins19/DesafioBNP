using DesafioBNP.Business.Notifications;

namespace DesafioBNP.Business.Intefaces
{
    public interface INotificator
    {
        bool HasNotifications();

        List<Notification> GetNotifications();

        void Handle(Notification notification);
    }
}