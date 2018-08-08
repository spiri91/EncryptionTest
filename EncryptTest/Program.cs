using System;
using IsPossibleEncryption;
using Pipe4Net;

namespace EncryptTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var _awesome = new Candidates();

            _awesome.Check("foo", "bar").PipeWith(Console.WriteLine);

            _awesome.Check("foo", "baa").PipeWith(Console.WriteLine);

            Console.ReadKey();
        }
    }
}
