using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BattleshipStateTracker.Test.IntegrationTest
{
    public class AddBattleshipTest : BattleshipIntegrationTestBase
    {
        [Fact]
        public async Task AddBattleship_Success()
        {
            await _controller.Create("a");
            var response = await _controller.AddBattleShip("a", 1,1, 1,2);
            var okResult = response as OkObjectResult;
            
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
        
        [Fact]
        public async Task AddBattleship_Fail()
        {
            await _controller.Create("");
            var response = await _controller.AddBattleShip("a", 1,3, 1,2);
            var badRequestResult = response as BadRequestObjectResult;
            
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Can't add battleship to the board.", badRequestResult.Value);
        }
    }
}