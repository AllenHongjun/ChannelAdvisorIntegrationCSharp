

using Aarvani.ChannelAdvisor.Entities;
using Aarvani.ChannelAdvisor.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ChannelAdvisorTest.Services
{
    [TestClass]
    public class AuthTokenServiceTest
    {

        [TestMethod]
        public async Task  Should_Get_NewToken() {

            //Arrange
            AuthToken token;

            //Act
            token = await AuthTokenService.GetNewToken();

            //Assert
            Assert.IsNotNull(token);

        }
    }
}
