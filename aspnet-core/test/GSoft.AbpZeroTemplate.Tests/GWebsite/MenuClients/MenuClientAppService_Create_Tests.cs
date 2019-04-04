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
    public class MenuClientAppService_Create_Tests : MenuClientAppServiceTestBase
    {
        [MultiTenantFact]
        public async Task Should_Create_Menu_Client()
        {
            LoginAsHostAdmin();
            await CreateMenuClientAndTestAsync("menuuu1", "decriptionn1");
            await CreateMenuClientAndTestAsync("menuuu2", "decriptionn2");
        }

        private async Task CreateMenuClientAndTestAsync(string name, string decription)
        {
            //Act
            await _menuClientAppService.CreateMenuClientAsync(
                new CreateMenuClientInput
                {
                    Name = name,
                    Description = decription,
                    Alias = "sdfsdf"
                });

            //Assert
            await UsingDbContextAsync(async context =>
            {
                //Get created menu
                var createdMenu = await context.MenuClients.FirstOrDefaultAsync(x => x.Name == name && x.Description == decription);
                createdMenu.ShouldNotBe(null);

                //Check some properties
                createdMenu.Name.ShouldBe(name);
                createdMenu.Description.ShouldBe(decription);
            });
        }
    }
}
