using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BattleshipStateTracker.Test.IntegrationTest
{
    public class AddBattleship : BattleshipControllerTestBase
    {
        [Fact]
        public async Task AddBattleshipController()
        {
            await _controller.Create("a");
            var response = await _controller.AddBattleShip("a", 1,1, 1,2);
            var okResult = response as OkObjectResult;
            
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}