using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.MultiTenancy.HostDashboard.Dto;

namespace GSoft.AbpZeroTemplate.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}