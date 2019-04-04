using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CustomerController : GWebsiteControllerBase
    {
        private readonly ICustomerAppService customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<CustomerDto> GetCustomersByFilter(CustomerFilter customerFilter)
        {
            return customerAppService.GetCustomers(customerFilter);
        }

        [HttpGet]
        public CustomerInput GetCustomerForEdit(int id)
        {
            return customerAppService.GetCustomerForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditCustomer([FromBody] CustomerInput input)
        {
            customerAppService.CreateOrEditCustomer(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            customerAppService.DeleteCustomer(id);
        }

        [HttpGet]
        public CustomerForViewDto GetCustomerForView(int id)
        {
            return customerAppService.GetCustomerForView(id);
        }
    }
}
