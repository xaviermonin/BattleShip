using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Engine.Exception
{

    [Serializable]
    public class InvalidBoardException : System.Exception
    {
        public InvalidBoardException() { }
        public InvalidBoardException(string message) : base(message) { }
        public InvalidBoardException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidBoardException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
