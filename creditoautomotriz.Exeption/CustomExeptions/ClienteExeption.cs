using System;

namespace creditoautomotriz.Exeption
{
    
    public class ClienteExeption : Exception
    {
        public ClienteExeption() { }
        public ClienteExeption(string message) : base(message) { }
        public ClienteExeption(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
