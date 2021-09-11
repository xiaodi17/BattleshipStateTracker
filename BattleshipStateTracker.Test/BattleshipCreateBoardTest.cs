using System;
using System.Linq;
using BattleshipStateTracker.Service;
using BattleshipStateTracker.Service.Models;
using Xunit;

namespace BattleshipStateTracker.Test
{
    public class BattleshipCreateBoardTest
    {
        private readonly BattleshipService _battleshipService;

        public BattleshipCreateBoardTest()
        {
            _battleshipService = new BattleshipService();
        }

        [Fact]
        public void CreateBoard()
        {
            _battleshipService.CreateBoard("A");
            var board = _battleshipService._boards.FirstOrDefault(i => i.BoardId == "A");

            Assert.Equal(100, board.Cells.Count);
        }
    }
}