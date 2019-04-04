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
    public class MenuClientAppService_Delete_Tests : MenuClientAppServiceTestBase
    {
        [MultiTenantFact]
        public async Task Should_Delete_Menu_Client()
        {
            LoginAsHostAdmin();
            CreateMenuClientData();
            await UpdateMenuClientAndTestAsync(1, "menuuu1", "decriptionn1", "trang-chu");
            await UpdateMenuClientAndTestAsync(2, "menuuu2", "decriptionn2", "san-pham");
        }

        private async Task UpdateMenuClientAndTestAsync(int id, string name, string decription, string alias)
        {
            //Act
            await _menuClientAppService.UpdateMenuClientAsync(
                new UpdateMenuClientInput
                {
                    Id = id,
                    Name = name,
                    Description = decription,
                    Alias = alias
                });

            //Assert
            await UsingDbContextAsync(async context =>
            {
                //Get created update
                var updatedMenu = await context.MenuClients.FirstOrDefaultAsync(x => x.Id == id);
                updatedMenu.ShouldNotBe(null);

                //Check some properties
                updatedMenu.Name.ShouldBe(name);
                updatedMenu.Description.ShouldBe(decription);
                updatedMenu.Alias.ShouldBe(alias);
            });
        }
    }
}
