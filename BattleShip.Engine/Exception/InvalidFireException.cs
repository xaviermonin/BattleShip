using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Engine.Exception
{

    [Serializable]
    public class InvalidFireException : System.Exception
    {
        public InvalidFireException() { }
        public InvalidFireException(string message) : base(message) { }
        public InvalidFireException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidFireException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
