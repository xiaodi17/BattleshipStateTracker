using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BattleshipStateTracker.Test.IntegrationTest
{
    public class BattleshipCreateControllerTest : BattleshipControllerTestBase
    {
        [Fact]
        public async Task CreateController()
        {
            var response = await _controller.Create("A", 10);
            var okResult = response as OkResult;
            
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}