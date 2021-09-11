using System;
using BattleshipStateTracker.Service.Models;

namespace BattleshipStateTracker.Service
{
    public class BattleshipService: IBattleshipService
    {
        public BattleshipService()
        {
        }

        public Board board { get; set; }
        public void CreateBoard(int size = 10)
        {
            board = new Board(size);
        }
    }
}