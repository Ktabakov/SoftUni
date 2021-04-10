using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> mystack = new MyStack<int>();

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                string[] cmdArg = cmd.Split(new string[] { " ", ", "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdArg[0] == "Push")
                {
                    for (int i = 1; i < cmdArg.Length; i++)
                    {
                        mystack.Push(int.Parse(cmdArg[i]));
                    }
                }
                else if (cmdArg[0] == "Pop")
                {
                    try
                    {
                        mystack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                cmd = Console.ReadLine();
            }

            foreach (var item in mystack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(string.Join(Environment.NewLine, mystack));
        }
    }
}
