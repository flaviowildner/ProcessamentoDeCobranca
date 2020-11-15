using System;

namespace ClienteAPI.Util
{
    public interface ICPFFormatter
    {
        string ToString(long input);
        long ToLong(string input);
    }
}