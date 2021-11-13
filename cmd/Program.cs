using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cmd
{
    internal class Program
    {
        static int timeout { get; set; } = 1000;
        static string dir { get; set; }
        static void Main(string[] args)
        {
            dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\qaner";
            bool ready = false;

            if (Directory.Exists(dir))
            {
                Console.WriteLine("loading " + dir + @"\qwin.bin...\n");
            }
            else
            {
                timeout = 4000;
                ready = true;
                Console.WriteLine("The bakgrud Service not run or installed!");
            }

            System.Threading.Thread.Sleep(timeout);

            while (!ready)
            {
                Console.Write("qaner:cmd>");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "debug":
                        Console.WriteLine("\n---debug.log---\n" + File.ReadAllText(dir + @"\debug.log") + "\n---end debug.log---");
                        break;
                    case "exit":
                        ready = true;
                        break;
                    case "_winres__qad":
                        Console.WriteLine(dir);
                        break;

                    case "clear":
                        Console.Clear();
                        break;

                    case "_winres__*":
                        Console.WriteLine("typedef qad::main(0=0);");
                        break;
                    case "help":
                        Console.WriteLine("help   Display the helpmsg!\n");
                        Console.WriteLine("exit   Exit the Cmd!\n");
                        Console.WriteLine("_*__*  Get a win res!\n");
                        break;

                    default:
                        Console.WriteLine("Command Not fund!");
                        break;
                }
            }

            //Console.WriteLine("\n---debug.log---\n" + File.ReadAllText(dir + @"\debug.log") + "\n---end debug.log---");
            //Console.ReadKey();
        }
    }
}
