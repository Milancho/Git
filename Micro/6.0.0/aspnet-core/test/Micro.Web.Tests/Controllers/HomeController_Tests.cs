using System.Threading.Tasks;
using Micro.Models.TokenAuth;
using Micro.Web.Controllers;
using Shouldly;
using Xunit;

namespace Micro.Web.Tests.Controllers
{
    public class HomeController_Tests: MicroWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}