using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.Service;
using BattleshipStateTracker.Service.Exceptions;
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
        
        [Fact]
        public async Task AddBattleship_Not_Vertical_Horizontal()
        {
            _battleshipService.CreateBoard("A");
            var startCoord = new Point(8, 2);
            var endCoord = new Point(2, 1);

            var ex = await Assert.ThrowsAsync<InvalidBattleshipCreateException>(() => _battleshipService.AddBattleShip(
                "A",
                startCoord,
                endCoord));
 
            Assert.Equal("Ship has to be vertical or horizontal.", ex.Message);
            
        }
        
        [Fact]
        public async Task AddBattleship_Outside_Board()
        {
            _battleshipService.CreateBoard("A");
            var startCoord = new Point(2, 1);
            var endCoord = new Point(11, 1);
            var ex = await Assert.ThrowsAsync<InvalidBattleshipCreateException>(() => _battleshipService.AddBattleShip(
                "A",
                startCoord,
                endCoord));
 
            Assert.Equal("Invalid position to create battleship.", ex.Message);
        }
    }
}