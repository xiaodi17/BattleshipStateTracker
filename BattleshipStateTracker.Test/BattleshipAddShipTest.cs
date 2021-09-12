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
        
        [Fact]
        public async Task AddBattleship_Not_Vertical_Horizontal()
        {
            _battleshipService.CreateBoard("A");
            var startCoord = new Point(8, 2);
            var endCoord = new Point(2, 1);

            var battleShip = await _battleshipService.AddBattleShip("A", startCoord, endCoord);
            
            Assert.Null(battleShip);
            
        }
        
        [Fact]
        public async Task AddBattleship_Outside_Board()
        {
            _battleshipService.CreateBoard("A");
            var startCoord = new Point(2, 1);
            var endCoord = new Point(11, 1);
            var battleShip = await _battleshipService.AddBattleShip("A", startCoord, endCoord);
            
            Assert.Null(battleShip);
        }
        
        [Fact]
        public async Task AddBattleship_On_Occupied_Cell()
        {
            _battleshipService.CreateBoard("A");
            var firstShipStartCoord = new Point(2, 1);
            var firstShipEndCoord = new Point(9, 1);

            var secondShipStartCoord = new Point(5, 1);
            var secondShipEndCoord = new Point(8, 1);
            await _battleshipService.AddBattleShip("A", firstShipStartCoord, firstShipEndCoord);
            
            var battleShip = await _battleshipService.AddBattleShip("A", secondShipStartCoord, secondShipEndCoord);
            Assert.Null(battleShip);
        }
    }
}