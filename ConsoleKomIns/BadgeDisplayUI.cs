using _03_KomInsClassLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomBadgeConsole
{
    class BadgeDisplayUI
    {
        private BadgeAccessDir _dataRepo = new BadgeAccessDir();

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
                        NewID();
                        break;
                    case "2":
                        UpdaeID();
                        break;
                    case "3":
                        DisplayID();
                        break;
                    case "4":
                        RemoveID();
                        break;
                    case "5":                                                                                                    
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
        
            if(DoorAccess = null)


            _dataRepo.AddDataToBadgeAccessDir(newData);
        }


        // #2 Diplay ID 
        private void UpdateID()
        {
            Console.Clear();

            List<CafeLibary> listOfData = _dataRepo.GetCafeLibaries();

            foreach (CafeLibary data in listOfData)
            {
                Console.WriteLine($"{data.MealNumber}, {data.MealName},\n" +
                       $"{data.Description},\n" +
                       $"Ingredients:\n" +
                       $"{data.Ingredients},\n" +
                       $"Price:\n" +
                       $"{data.Price}");
            }
        }

        // #4 Update
        private void DisplaybyBadgeID()
        {
            Console.Clear();
            Console.WriteLine("Enter The BadgeID");

            string mealName = Console.ReadLine();

            BadgeAccessDir data = _dataRepo.GetDataWithBadgeID(BadgeID);

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
        // #5 DELETE 
        private void RemoveSelection()
        {
            ViewMenu();

            //menu choice to be removed
            Console.WriteLine("Enter BadgeID for Remove:");
            string input = Console.ReadLine();

            bool wasDeleted = _dataRepo.RemoveDataFromBadgeDir(input);  //problem

            //If the content was deleted, say no
            if (wasDeleted)
            {
                Console.WriteLine("Your ID was deleted.");
            }
            else
            {
                Console.WriteLine("The ID was not deleted.");
            }

        }
        // #5a DELETE Existing Content
        private void RemoveBadgeIDSelection()
        {

        }

        // #7 SEED METHOD
        private void Sample()
        {
            BadgeAccessDir BadgeOne = new BadgeAccessDir(12345, "A7");
            BadgeAccessDir BadgeTwo = new BadgeAccessDir(22345, "A1, A4, B1, B2");
            BadgeAccessDir BadgeThree = new BadgeAccessDir(32345, "A4, A5");

            _dataRepo.AddDatatoBadgeID(BadgeOne);
            _dataRepo.AddDatatoBadgeID(BadgeTwo);
            _dataRepo.AddDatatoBadgeID(BadgeThree);

        }
    }
}
