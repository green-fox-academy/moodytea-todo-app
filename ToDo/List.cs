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

        public List<string> TaskAdder(string addedTask)
		{
            ListOfTasks();
            listAsIs.Add(addedTask);
            if (addedTask.Length.Equals(0))
            {
                Console.WriteLine("Unable to add: no task provided");
            }
            File.AppendAllText("..//..//todolist.txt", "\n" + addedTask);
            return listAsIs;
		}

		public List<string> TaskRemover(int taskNumber)
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

            return listAsIs;
			
		}


       
    }
}