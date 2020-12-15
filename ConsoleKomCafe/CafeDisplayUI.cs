﻿using _01_KomCafeClassLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomCafeConsole
{
    class CafeDisplayUI
    {
        private CafeRepo _dataRepo = new CafeRepo();

          //RUN METHOD
        public void Run()
        {
            ExampleData();
            Menu();
        }

           // #1 MENU
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                    //Menu Option
                Console.WriteLine("Select from the Following:\n" +
                    "1 Create New Meal Choice\n" +
                    "2 View Menu\n" +
                    "3 Remove Menu Selection\n" +
                    "4 Exist");
                 
                    //User Input
                string userInput = Console.ReadLine();

                    //Evaluate User's Input
                switch (userInput)
                {
                    case "1":
                        NewEntry();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        RemoveSelection();
                        break;
                    case "4":
                        Console.WriteLine("Thank You");
                        keepRunning = false;
                        break;
                }

                Console.WriteLine("Please make another selection");
                Console.ReadKey();
                Console.Clear();
            }
        }

              // #2 CREATE NEW == User input forum == New Data
        private void NewEntry()
        {
            Console.Clear();
            CafeLibary newData = new CafeLibary();

            //MealNumber
            Console.WriteLine("Enter Number");
            string numberAsString = Console.ReadLine();
            int numberAsInt = int.Parse(numberAsString);
            newData.MealNumber = numberAsInt;

            //MealName
            Console.WriteLine("Meal Name");
            newData.MealName = Console.ReadLine();

            //Description
            Console.WriteLine("Brief Description");
            newData.Description = Console.ReadLine();

            //Ingredients 
            Console.WriteLine("Top Five Ingredients");
            newData.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("Meal Price $00.00");
            string priceAsString = Console.ReadLine();
            newData.Price = double.Parse(priceAsString);

            _dataRepo.AddDatatoMenu(newData);
        }


            // #3 VIEW CURRENT == Currenting CafeLibary  
        private void ViewMenu()
        {
            Console.Clear();

            List<CafeLibary> listOfData = _dataRepo.GetCafeLibaries();

            foreach(CafeLibary data in listOfData)
            {
                Console.WriteLine($"{data.MealNumber}, {data.MealName},\n" +
                       $"{data.Description},\n" +
                       $"Ingredients:\n" +
                       $"{data.Ingredients},\n" +
                       $"Price:\n" +
                       $"{data.Price}");
            }
        }

           // #4 VIEW EXISTING data
        private void DisplaybyMealNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of the meal you would like to order");

            string mealName = Console.ReadLine();

            CafeLibary data = _dataRepo.GetDataWithMealName(mealName);

            if (data != null)
            {
                Console.WriteLine($"Title: {data.MealName},\n" +
                    $"Description: {data.Description},\n" +
                    $"Ingredients: {data.Ingredients},\n" +
                    $"Price: {data.Price}");
            }
            else
            {
                Console.WriteLine("That Item is Not Available. Please Make Another Selection ");
            }
        }
           // #6 DELETE EXISTING Content
        private void RemoveSelection()
        {
            ViewMenu();

                //menu choice to be removed
            Console.WriteLine("Enter The Menu Selection To Be Remove:");
            string input = Console.ReadLine();

            bool wasDeleted = _dataRepo.RemoveDataFromDir(input);  //problem
           
                //If the content was deleted, say no
            if (wasDeleted)
            {
                Console.WriteLine("The Selection was deleted.");
            }
            else
            {
                Console.WriteLine("The Slection was not deleted.");
            }

        }
            // #6a DELETE EXISTING Content
        private void RemoveMenuSelection()
        {

        }

            // #7 SEED METHOD
        private void ExampleData()
        {
            CafeLibary BLT = new CafeLibary(1, "BLT", "Bacon Lettuce and Tomato Sandwich", "Pork Bacon Lettuce, Tomato, Mayo and Rye Bread", 4.99);
            CafeLibary Hamburger = new CafeLibary(2, "Hamburger", "Angus Beef with American Cheese on a WHole Wheat Bun", "Beef, American Cheese, Lettuce, Onion, Tomato and Wheat Bread", 5.99);
            CafeLibary Reuben = new CafeLibary(3, "Reuben Sandwich", "Grilled Corn Beef Sandwich serviced with a dill Pickel", "Corn Beef, Swiss Cheese,Sauerkraut and Russian Dressing", 8.99);

            _dataRepo.AddDatatoMenu(BLT);
            _dataRepo.AddDatatoMenu(Hamburger);
            _dataRepo.AddDatatoMenu(Reuben);

        }
  
    }
}

