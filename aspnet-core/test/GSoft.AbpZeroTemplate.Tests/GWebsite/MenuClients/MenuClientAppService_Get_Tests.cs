using System.Linq;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using GSoft.AbpZeroTemplate.Authorization.Roles;
using GSoft.AbpZeroTemplate.Authorization.Users.Dto;
using GSoft.AbpZeroTemplate.MultiTenancy;
using Shouldly;
using Xunit;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.MenuClients
{
    public class MenuClientAppService_Get_Tests : MenuClientAppServiceTestBase
    {
        [MultiTenantFact]
        public async Task Get_All_Menu_Client_Test()
        {
            LoginAsHostAdmin();
            CreateMenuClientData();
            var menuClients = await _menuClientAppService.GetMenuClientsAsync();
            menuClients.Items.Count.ShouldBe(5);
        }

        private async Task Get_Menu_Client_Page_0_Test()
        {
            LoginAsHostAdmin();
            CreateMenuClientData();
            var menuClientsPaging = await _menuClientAppService.GetMenuClientsAsync(new GetMenuClientInput()
            {
                MaxResultCount = 3,
                SkipCount = 0
            });
            menuClientsPaging.TotalCount.ShouldBe(5);
            menuClientsPaging.Items.Count.ShouldBe(3);
            menuClientsPaging.Items[0].Name.ShouldBe("menu1");
            menuClientsPaging.Items[0].Alias.ShouldBe("trang-chu");
            menuClientsPaging.Items[2].Name.ShouldBe("menu3");
            menuClientsPaging.Items[2].Alias.ShouldBe("blog-er");
        }

        private async Task Get_Menu_Client_Page_2_Test()
        {
            LoginAsHostAdmin();
            CreateMenuClientData();
            var menuClientsPaging = await _menuClientAppService.GetMenuClientsAsync(new GetMenuClientInput()
            {
                MaxResultCount = 3,
                SkipCount = 1
            });
            menuClientsPaging.TotalCount.ShouldBe(5);
            menuClientsPaging.Items.Count.ShouldBe(2);
            menuClientsPaging.Items[0].Name.ShouldBe("menu4");
            menuClientsPaging.Items[0].Alias.ShouldBe("blog-er");
            menuClientsPaging.Items[1].Name.ShouldBe("menu5");
            menuClientsPaging.Items[1].Alias.ShouldBe("tyt-er");
        }
    }
}
