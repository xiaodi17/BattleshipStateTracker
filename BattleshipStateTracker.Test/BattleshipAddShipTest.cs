using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.Service;
using Xunit;

namespace BattleshipStateTracker.Test
{
    public class BattleshipAddShipTest
    {
        private readonly BattleshipService _battleshipService;

        public BattleshipAddShipTest()
        {
            _battleshipService = new BattleshipService();
        }
        
        [Fact]
        public async Task AddBattleship()
        {
            _battleshipService.CreateBoard("A");
            var startCoord = new Point(1, 1);
            var endCoord = new Point(2, 1);
            var ship = await _battleshipService.AddBattleShip("A",startCoord, endCoord);

            Assert.Equal(2, ship.Cells.Count);
        }
    }
}