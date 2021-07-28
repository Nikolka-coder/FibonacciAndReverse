using System;
using System.IO;

namespace FibonacciAndReverse
{
    static class Console
    {
        static readonly string _logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

        public static void WriteLine()
        {
            File.AppendAllText(_logPath, Environment.NewLine);
            System.Console.WriteLine();
        }

        public static void WriteLine(string line)
        {
            File.AppendAllText(_logPath, line + Environment.NewLine);
            System.Console.WriteLine(line);
        }

        public static void Write(string line)
        {
            File.AppendAllText(_logPath, line);
            System.Console.Write(line);
        }

        public static void Write(int n)
        {
            File.AppendAllText(_logPath, n.ToString());
            System.Console.Write(n);
        }
        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }
        public static string ReadLine(string line)
        {
            File.AppendAllText(_logPath, line);
            System.Console.WriteLine(line);
            return ReadLine();
        }
    }
}
