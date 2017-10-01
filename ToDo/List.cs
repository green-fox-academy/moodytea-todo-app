using System;
using System.Collections.Generic;
using System.IO;

namespace ToDo
{
    public class MyList
    {
        public static List<string> listAsIs = new List<string>(){};
        public static string[] stringToConvert = File.ReadAllLines("..//..//todolist.txt");


        public static List<string> ListOfTasks()
        {
            try
            {
				foreach (string s in stringToConvert)
				{
					listAsIs.Add(s);
				}
            }
            catch (Exception ex)
            {
                Console.WriteLine("conversion error:" + ex);
            }

            return listAsIs;

        }

		public void TaskLister()
		{
            ListOfTasks();
            if (listAsIs.Count.Equals(0))
			{
				Console.WriteLine("No 2Dos for today");
			}
            else
            {
				int i = 1;
                foreach (string todos in listAsIs)
				{ 
					Console.WriteLine( (i) + " - " + todos);
					i++;
				}
            }
		}

		public void TaskChecker(int taskNumber)
		{
			ListOfTasks();
			if (listAsIs.Count.Equals(0))
			{
				Console.WriteLine("No 2Dos for today");
			}
			else
			{
				int j = 1;
				foreach (string todos in listAsIs)
				{
                    if (j == taskNumber)
                    {
                        Console.WriteLine("[x]" + todos);
                    }
                        
                    else
                    {
                    Console.WriteLine("[ " + "]" + todos);
					}
					j++;
				}
			}
			listAsIs.RemoveAt(taskNumber - 1);

			File.Delete("..//..//todolist.txt");
			int i = 1;
			foreach (string todos in listAsIs)
			{
				if (i == 1)
				{
					File.AppendAllText("..//..//todolist.txt", todos);
					i--;
				}
				else
					File.AppendAllText("..//..//todolist.txt", "\n" + todos);
			}

		}

        public void TaskAdder(string addedTask)
		{
            ListOfTasks();
            listAsIs.Add(addedTask);
            if (addedTask.Length.Equals(0))
            {
                Console.WriteLine("Unable to add: no task provided");
            }
            File.AppendAllText("..//..//todolist.txt", "\n" + addedTask);
		}

		public void TaskRemover(int taskNumber)
		{
            ListOfTasks();

            listAsIs.RemoveAt(taskNumber - 1);

			File.Delete("..//..//todolist.txt");
            int i = 1;
            foreach (string todos in listAsIs)
			{
                if (i == 1)
                {
                    File.AppendAllText("..//..//todolist.txt", todos);
                    i--;
                }
                else
				File.AppendAllText("..//..//todolist.txt", "\n" + todos);
			}
			
		}


       
    }
}