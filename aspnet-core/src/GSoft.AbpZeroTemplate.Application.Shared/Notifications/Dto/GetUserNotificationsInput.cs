using Abp.Notifications;
using GSoft.AbpZeroTemplate.Dto;

namespace GSoft.AbpZeroTemplate.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}