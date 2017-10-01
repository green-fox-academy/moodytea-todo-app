using System;
using System.Linq;

namespace ToDo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //args = new string[]{"-r"};
            MyList myList = new MyList();
            if (args.Length.Equals(0))
            {
				Console.WriteLine("Command Line Todo application");
				Console.WriteLine("=============================");
				Console.WriteLine("");
				Console.WriteLine("Command line arguments:");
				Console.WriteLine("-l   Lists all the tasks");
				Console.WriteLine("-a   Adds a new task");
				Console.WriteLine("-r   Removes an task");
				Console.WriteLine("-c   Completes an task");
            }
            else if (args.Contains("-l"))
            {
                myList.TaskLister();
            }
			else if (args.Contains("-a"))
            {	
				if (args[1].Equals(""))
				{
					Console.WriteLine("Unable to add: no task provided");
				}
				else
				{
					myList.TaskAdder(args[1]);

				}
            }
            else if (args.Contains("-r"))
            {
                int num = -1;

                if (args.Count()==1)
                {
                    Console.WriteLine("Unable to remove: no index provided");
                }
                else if (!Int32.TryParse(args[1], out num))
				{
					Console.WriteLine("Unable to remove: index is not a number");
				}
                else if (args[1].Equals(""))
				{
					Console.WriteLine("Unable to remove: no index provided");
				} 
                else if (num > (MyList.stringToConvert.Count()) || num < 0)
				{
					Console.WriteLine("Unable to remove: index out of range");
				}
                else
                {
                    myList.TaskRemover(num);

                }

            }
			else if (args.Contains("-c"))
			{
				int num = -1;

				if (args.Count() == 1)
				{
					Console.WriteLine("Unable to check: no index provided");
				}
				else if (!Int32.TryParse(args[1], out num))
				{
					Console.WriteLine("Unable to check: index is not a number");
				}
				else if (args[1].Equals(""))
				{
					Console.WriteLine("Unable to check: no index provided");
				}
				else if (num > (MyList.stringToConvert.Count()) || num < 0)
				{
					Console.WriteLine("Unable to check: index out of range");
				}
				else
				{
					myList.TaskChecker(num);

				}

			}
               
                  
        }
    }
}
