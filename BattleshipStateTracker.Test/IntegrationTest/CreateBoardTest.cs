using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BattleshipStateTracker.Test.IntegrationTest
{
    public class CreateBoardTest : BattleshipIntegrationTestBase
    {
        [Fact]
        public async Task CreateBoard_Success()
        {
            var response = await _controller.Create("A", 10);
            var okResult = response as OkObjectResult;
            
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
        
        [Fact]
        public async Task CreateBoard_Fail()
        {
            var response = await _controller.Create("", 10);
            var badRequestResult = response as BadRequestObjectResult;
            
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Board can't be created.", badRequestResult.Value);
        }
    }
}