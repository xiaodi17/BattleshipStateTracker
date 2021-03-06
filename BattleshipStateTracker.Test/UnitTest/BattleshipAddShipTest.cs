using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.Service;
using Xunit;

namespace BattleshipStateTracker.Test.UnitTest
{
    public class BattleshipAddShipTest : BattleshipUnitTestBase
    {
        [Fact]
        public async Task AddBattleship()
        {
            await _battleshipService.CreateBoard("A");
            var startCoord = new Point(1, 1);
            var endCoord = new Point(2, 1);
            var ship = await _battleshipService.AddBattleShip("A",startCoord, endCoord);

            Assert.NotNull(ship);
            Assert.Equal(2, ship.Cells.Count);
        }
        
        [Fact]
        public async Task AddBattleship_Not_Vertical_Horizontal()
        {
            await _battleshipService.CreateBoard("A");
            var startCoord = new Point(8, 2);
            var endCoord = new Point(2, 1);

            var battleShip = await _battleshipService.AddBattleShip("A", startCoord, endCoord);
            
            Assert.Null(battleShip);
            
        }
        
        [Fact]
        public async Task AddBattleship_Outside_Board()
        {
            await _battleshipService.CreateBoard("A");
            var startCoord = new Point(2, 1);
            var endCoord = new Point(11, 1);
            var battleShip = await _battleshipService.AddBattleShip("A", startCoord, endCoord);
            
            Assert.Null(battleShip);
        }
        
        [Fact]
        public async Task AddBattleship_On_Occupied_Cell()
        {
            await _battleshipService.CreateBoard("A");
            var firstShipStartCoord = new Point(2, 1);
            var firstShipEndCoord = new Point(9, 1);

            var secondShipStartCoord = new Point(5, 1);
            var secondShipEndCoord = new Point(8, 1);
            await _battleshipService.AddBattleShip("A", firstShipStartCoord, firstShipEndCoord);
            
            var battleShip = await _battleshipService.AddBattleShip("A", secondShipStartCoord, secondShipEndCoord);
            Assert.Null(battleShip);
        }
        
        [Fact]
        public async Task AddBattleship_Edge_Case_Vertical()
        {
            await _battleshipService.CreateBoard("A");
            var firstShipStartCoord = new Point(9, 1);
            var firstShipEndCoord = new Point(2, 1);
            
            var battleShip = await _battleshipService.AddBattleShip("A", firstShipStartCoord, firstShipEndCoord);
            
            Assert.NotNull(battleShip);
            Assert.Equal(8, battleShip.Cells.Count);
        }
        
        [Fact]
        public async Task AddBattleship_Edge_Case_Horizontal()
        {
            await _battleshipService.CreateBoard("A");
            var firstShipStartCoord = new Point(1, 9);
            var firstShipEndCoord = new Point(1, 3);
            
            var battleShip = await _battleshipService.AddBattleShip("A", firstShipStartCoord, firstShipEndCoord);
            
            Assert.NotNull(battleShip);
            Assert.Equal(7, battleShip.Cells.Count);
        }
    }
}