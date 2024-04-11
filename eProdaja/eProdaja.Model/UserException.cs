using System;

namespace eProdaja.Model
{
    public class UserException : Exception
    {
        public UserException(string msg) : base (msg) {}
    }
}
