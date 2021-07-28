using System;
using System.IO;

namespace FibonacciAndReverse
{
    class Program
    {
        public static int Fib(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static void Main(string[] args)
        {
            string text = "\n row 1\n row 2\n row 3\n row 4\n row 5\n row 6\n row 7\n row 8\n row 9\n row 10\n";

            string path = @"D:\source";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            using (FileStream fstream = new FileStream($"{path}/source.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }
            using (FileStream fstream = File.OpenRead($"{path}/source.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла source.txt: {textFromFile}");
            }

            
            using (FileStream fstream = new FileStream($"{path}/output.txt", FileMode.OpenOrCreate))
            {
                string[] mystring = text.Split('\n');
                string str;
                for (int i = 1; i < mystring.Length; i++)
                {
                    for (int n = 2; n < 10; n++)
                    {
                        int f = Fib(n);
                        if (i == f)
                        {
                            str = string.Join('\n', Reverse(mystring[i]));
                            byte[] array = System.Text.Encoding.Default.GetBytes(str);
                            fstream.Write(array, 0, array.Length);
                        }
                    }
                }
            }
            using (FileStream fstream = File.OpenRead($"{path}/output.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла output.txt: {textFromFile}");
            }

            Console.ReadLine();
        }
    }
}
