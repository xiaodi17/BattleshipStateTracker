using System;

namespace BattleshipStateTracker.Service.Exceptions
{
    public class InvalidAttackException : Exception
    {
        public InvalidAttackException(string message) : base(message)
        {
        }
    }
}