using System;

namespace ClienteAPI.Util
{
    public interface ICPFFormatter
    {
        string ToString(long cpf);
        long ToLong(string cpf);
    }
}