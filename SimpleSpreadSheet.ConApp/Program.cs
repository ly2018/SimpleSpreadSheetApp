using System;
using SimpleSpreadSheet.ConApp.SheetHelper;
using System.Linq;

namespace SimpleSpreadSheet.ConApp
{
    /// <summary>
    ///In a nutshell, the program should work as follows:
	///Create a new spread sheet
	///Add numbers in different cells and perform some calculation on top of specific row or column
	///Qui
    /// </summary>
    class Program
    {
        
        static void Main(string[] args)
        {
            bool hasInitSheet = false;//first step must init a sheet

            SimpleSheet simpleSheet = new SimpleSheet();
            string str = string.Empty;
            int x = 0, y = 0, z = 0;
            while (true)
            {
                Console.Write("enter command: ", ConsoleColor.Blue);
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    Environment.Exit(-1);
                }
                if (string.IsNullOrWhiteSpace(input) || !(input.ToLower().StartsWith("n") || input.ToLower().StartsWith("c") || input.ToLower().StartsWith("s")))
                {
                    Console.Write("error input , please enter command again: ", ConsoleColor.Red);
                    continue;
                }
                string[] arr = input.Split(' ');
                if (arr.Any(a => a.Length > 3))
                {
                    Console.Write("error input each cell will allocate at most 3 characters, please enter command again: ", ConsoleColor.Red);
                    continue;
                }
                x = 0;
                y = 0;
                z = 0;
                if (input.ToLower().StartsWith("c") && arr.Length == 3)
                {
                    if (int.TryParse(arr[1], out x) && int.TryParse(arr[2], out y))
                    {
                        str = simpleSheet.InitSheet(x, y);
                        hasInitSheet = true;
                        Console.WriteLine(str);
                    }
                }
                else if (hasInitSheet && input.ToLower().StartsWith("n") && arr.Length == 4)
                {
                    if (int.TryParse(arr[1], out x) && int.TryParse(arr[2], out y) && int.TryParse(arr[3], out z))
                    {
                        str = Utils.CalculateNewOutPut(str, x, y, z);
                        Console.WriteLine(str);
                    }
                }
                else if (hasInitSheet && input.ToLower().StartsWith("s") && arr.Length >= 5 && arr.Length % 2 == 1)
                {
                    var newArr = arr.Skip(1).Select(a => Convert.ToInt32(a)).ToArray();
                    str = Utils.CalculateSumOutPut(str, newArr);
                    Console.WriteLine(str);
                }
                else
                {
                    Console.Write("Error occurs ,you must create a sheet like input 'C 40 4', please enter command again: ", ConsoleColor.Red);
                    continue;
                }
                Console.WriteLine("Press any key continue,press 'q' to  quit !", ConsoleColor.Blue);
                Console.ReadKey();
            }
        }
    }
}
