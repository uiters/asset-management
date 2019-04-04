using GSoft.AbpZeroTemplate.Auditing;
using Shouldly;
using Xunit;

namespace GSoft.AbpZeroTemplate.Tests.Auditing
{
    public class NamespaceStripper_Tests: AppTestBase
    {
        private readonly INamespaceStripper _namespaceStripper;

        public NamespaceStripper_Tests()
        {
            _namespaceStripper = Resolve<INamespaceStripper>();
        }

        [Fact]
        public void Should_Stripe_Namespace()
        {
            var controllerName = _namespaceStripper.StripNameSpace("GSoft.AbpZeroTemplate.Web.Controllers.HomeController");
            controllerName.ShouldBe("HomeController");
        }

        [Theory]
        [InlineData("GSoft.AbpZeroTemplate.Auditing.GenericEntityService`1[[GSoft.AbpZeroTemplate.Storage.BinaryObject, GSoft.AbpZeroTemplate.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null]]", "GenericEntityService<BinaryObject>")]
        [InlineData("CompanyName.ProductName.Services.Base.EntityService`6[[CompanyName.ProductName.Entity.Book, CompanyName.ProductName.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[CompanyName.ProductName.Services.Dto.Book.CreateInput, N...", "EntityService<Book, CreateInput>")]
        [InlineData("GSoft.AbpZeroTemplate.Auditing.XEntityService`1[GSoft.AbpZeroTemplate.Auditing.AService`5[[GSoft.AbpZeroTemplate.Storage.BinaryObject, GSoft.AbpZeroTemplate.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[GSoft.AbpZeroTemplate.Storage.TestObject, GSoft.AbpZeroTemplate.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],]]", "XEntityService<AService<BinaryObject, TestObject>>")]
        public void Should_Stripe_Generic_Namespace(string serviceName, string result)
        {
            var genericServiceName = _namespaceStripper.StripNameSpace(serviceName);
            genericServiceName.ShouldBe(result);
        }
    }
}
