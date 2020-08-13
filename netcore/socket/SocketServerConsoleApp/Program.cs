using System;

namespace SocketServerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SynchronousSocketListener.StartListening();
        }
    }
}
