using _03_KomInsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomBadgeConsole
{
    class BadgeDisplayUI
    {
        private BadgeRepo _badgeDir = new BadgeRepo();

        public void Run()
        {
            Sample();
            Terminal();
        }

        // Terminal
        private void Terminal()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Terminal Display
                Console.WriteLine("Select from the Following:\n" +
                    "1 Create New Badge ID\n" +
                    "2 Update ID's\n" +
                    "3 Display ID List\n" +
                    "4 Remove ID\n" +
                    "5 Exist");

                //User Input
                string userInput = Console.ReadLine();

                //Evaluate User's Input
                switch (userInput)
                {
                    case "1":
                        //Input 
                        NewID();
                        break;
                    case "2":
                        //Update
                        UpdateID();
                        break;
                    case "3":
                        //Display 
                        DisplayIDs();
                        break;
                        //Remove
                    case "4":
                        RemoveID();
                        break;
                    case "5": 
                        //Exit
                        Console.WriteLine("Thank You");
                        keepRunning = false;
                        break;
                }

                Console.WriteLine("Please make another selection");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // #1 New ID
        private void NewID()
        {
            Console.Clear();
            BadgeAccessDir newData = new BadgeAccessDir();

            //Badge Number
            Console.WriteLine("Enter New ID Number");
            string numberAsString = Console.ReadLine();
            double numberAsDouble = double.Parse(numberAsString);
            newData.BadgeID = (int)numberAsDouble;

            //Door Access
            Console.WriteLine("Enter Door Access");
            newData.DoorAccess = Console.ReadLine();

            _badgeDir.AddDataToList(newData);
        }

        // #2 Update
        private void UpdateID()
        {
            Console.Clear();
            Console.WriteLine("Enter The BadgeID");

            string badgeID= Console.ReadLine();
            int result = Convert.ToInt32(badgeID);
            BadgeAccessDir data = _badgeDir.GetDataByBadgeID(result);

            if (data != null)
            {
                Console.WriteLine($"Badge#: {data.BadgeID},\n" +
                    $"DoorAccess: {data.DoorAccess}");
            }
            else
            {
                Console.WriteLine("Press any key return to terminal");    //wrong Console
            }
        }

        // #3 Diplay ID 
        private void DisplayIDs()
        {
            Console.Clear();

            List<BadgeAccessDir> listOfData = _badgeDir.GetBadgeAccessDir();

            foreach (BadgeAccessDir data in listOfData)
            {
                Console.WriteLine($"{data.BadgeID}, {data.DoorAccess}"); 
            }
        }


        // #4 DELETE 
        private void RemoveID()
        {
            DisplayIDs();

            Console.WriteLine("ID number for Remove:");

            string badgeID = Console.ReadLine();
            int result = Convert.ToInt32(badgeID);
            bool wasDeleted = _badgeDir.RemoveDataFromBadgeDir(result);  

            if (wasDeleted)
            {
                Console.WriteLine("ID was deleted.");
            }
            else
            {
                Console.WriteLine("The ID was not deleted.");
            }

        }

        // #7 SEED METHOD
        private void Sample()
        {
            BadgeAccessDir BadgeOne = new BadgeAccessDir(12345, "A7");
            BadgeAccessDir BadgeTwo = new BadgeAccessDir(22345, "A1, A4, B1, B2");
            BadgeAccessDir BadgeThree = new BadgeAccessDir(32345, "A4, A5");

            _badgeDir.AddDataToList(BadgeOne);
            _badgeDir.AddDataToList(BadgeTwo);
            _badgeDir.AddDataToList(BadgeThree);

        }
    }
}
