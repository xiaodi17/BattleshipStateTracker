using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BattleshipStateTracker.Test.IntegrationTest
{
    public class AttackBattleshipTest : BattleshipIntegrationTestBase
    {
        [Fact]
        public async Task AttackBattleship_Success()
        {
            await _controller.Create("a");
            await _controller.AddBattleShip("a", 1,1, 1,2);

            var response = await _controller.Attack("a",1, 1);
            var okResult = response as OkObjectResult;
            
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
        
        [Fact]
        public async Task AttackBattleship_Fail()
        {
            await _controller.Create("a");
            await _controller.AddBattleShip("a", 1,1, 1,2);

            var response = await _controller.Attack("a",11, 1);
            var badRequestResult = response as BadRequestObjectResult;
            
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
    }
}