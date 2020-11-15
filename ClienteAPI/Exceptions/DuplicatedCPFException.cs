using System;

namespace ClienteAPI.Exceptions
{
    public class DuplicatedCPFException : Exception
    {
        private static readonly string message = "Duplicated CPF";

        public DuplicatedCPFException() : base(message)
        {
        }
    }
}