namespace MyCompany.ECommerce.Api.Services
{
    public interface IEventNotificationService
    {
        void RaiseEvent(string eventName, params object[] parameters);
    }
}