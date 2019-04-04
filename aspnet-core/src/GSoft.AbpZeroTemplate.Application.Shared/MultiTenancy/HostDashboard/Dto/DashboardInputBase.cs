using System;

namespace GSoft.AbpZeroTemplate.MultiTenancy.HostDashboard.Dto
{
    public class DashboardInputBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}