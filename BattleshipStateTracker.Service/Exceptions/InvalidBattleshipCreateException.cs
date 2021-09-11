using System;

namespace BattleshipStateTracker.Service.Exceptions
{
    public class InvalidBattleshipCreateException : Exception
    {
        public InvalidBattleshipCreateException(string message) : base(message)
        {
        }
    }
}