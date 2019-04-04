using GWebsite.AbpZeroTemplate.Application.Share.MenuClients;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.MenuClients
{
    public abstract class MenuClientAppServiceTestBase : AppTestBase
    {
        protected readonly IMenuClientAppService _menuClientAppService;

        protected MenuClientAppServiceTestBase()
        {
            _menuClientAppService = Resolve<IMenuClientAppService>();
        }

        protected void CreateMenuClientData()
        {
            UsingDbContext(
               context =>
               {
                   context.MenuClients.Add(CreateMenuTest("menu1", "decription1", "trang-chu"));
                   context.MenuClients.Add(CreateMenuTest("menu2", "decription2", "san-pham"));
                   context.MenuClients.Add(CreateMenuTest("menu3", "decription3", "blog-er"));
                   context.MenuClients.Add(CreateMenuTest("menu4", "decription3", "blog-er"));
                   context.MenuClients.Add(CreateMenuTest("menu5", "decription3", "tyt-er"));
               });
        }

        private MenuClient CreateMenuTest(string name, string decription, string alias, bool status = true)
        {
            return new MenuClient()
            {
                Name = name,
                Description = decription,
                Alias = alias,
                Status = status
            };
        }
    }
}