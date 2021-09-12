using System.Drawing;
using System.Threading.Tasks;
using BattleshipStateTracker.Service;
using BattleshipStateTracker.Service.Models.Enums;
using Xunit;

namespace BattleshipStateTracker.Test.UnitTest
{
    public class BattleshipAttackTest
    {
        private readonly BattleshipService _battleshipService;

        public BattleshipAttackTest()
        {
            _battleshipService = new BattleshipService();
        }
        
        [Fact]
        public async Task AttackBattleship_Hit()
        {
            await _battleshipService.CreateBoard("A");
            var startCoord = new Point(1, 1);
            var endCoord = new Point(2, 1);
            var ship = await _battleshipService.AddBattleShip("A", startCoord, endCoord);
            var status = await _battleshipService.Attack("A", startCoord);

            Assert.Equal(CellStatus.Hit, status);
        }
        
        [Fact]
        public async Task AttackBattleship_Miss()
        {
            await _battleshipService.CreateBoard("A");
            var startCoord = new Point(1, 1);
            var endCoord = new Point(2, 1);
            var ship = await _battleshipService.AddBattleShip("A", startCoord, endCoord);
            var status = await _battleshipService.Attack("A", new Point(3,3));

            Assert.Equal(CellStatus.Miss, status);
        }
        
        [Fact]
        public async Task AttackBattleship_Out_Of_Board()
        {
            await _battleshipService.CreateBoard("A");
            var startCoord = new Point(1, 1);
            var endCoord = new Point(2, 1);
            var ship = await _battleshipService.AddBattleShip("A", startCoord, endCoord);
            var status = await _battleshipService.Attack("A", new Point(11,3));

            Assert.Null(status);
        }
    }
}