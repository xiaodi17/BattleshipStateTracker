using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.Service;
using Xunit;

namespace BattleshipStateTracker.Test.UnitTest
{
    public class BattleshipResetTest
    {
        private readonly BattleshipService _battleshipService;

        public BattleshipResetTest()
        {
            _battleshipService = new BattleshipService();
        }
        
        [Fact]
        public async Task Battleship_Reset()
        {
            await _battleshipService.CreateBoard("A");
            var boards = await _battleshipService.Reset();
            
            Assert.Empty(boards);
        }
    }
}