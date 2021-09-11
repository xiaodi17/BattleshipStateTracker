using System;
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
            _battleshipService.CreateBoard();
            //Assert board size 10*10
            //Assert ship on the board 0
            
            Assert.Equal(100, _battleshipService.board.Cells.Count);
        }
    }
}