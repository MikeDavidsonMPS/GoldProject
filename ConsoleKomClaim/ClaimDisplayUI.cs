using _02_KomdoClaimsClassLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKomClaim
{
    public class ClaimDisplayUI
    {
        private ClaimRepo _dataClaimsRepo = new ClaimRepo();

        public void Run()
        {
           SampleContent();
           ClaimsTermal();
        }
        private void ClaimsTermal()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display: Agent's Options
                Console.WriteLine("Select from the Following Options: \n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. End Session");

                // Agent's input 
                string input = Console.ReadLine();

                //Evaluate Agent's Input==act accordingly
                switch (input)
                {
                    case "1":
                        //View Claims
                        DisplayClaims();
                        break;
                    case "2":
                        // Assign Claim
                        AssignClaim();
                        break;
                    case "3":
                        // Input Claim
                        NewClaim();
                        break;
                    case "4":
                        // End Session: Exit
                        Console.WriteLine("Session has Terminated");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid: Enter valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // #1 VIEW CLAIMS List
        public void DisplayClaims()
        {
            Console.Clear();

            Queue<ClaimLibary> listOfData = _dataClaimsRepo.GetClaimsLibary();

            foreach (ClaimLibary data in listOfData)
            {
                Console.WriteLine($"ClaimID",   "ClaimType",   "Description",   "Settlement",   "Incident Date",   "Claim Date \n" +
                    $"{data.ClaimID},   {data.ClaimType},   {data.Description},   {data.Settlement},   {data.IncidentDate},   {data.ClaimDate}");
            }
        }


        // #2 ASSIGN CLAIM
        public void AssignClaim()
        {
            Queue<ClaimLibary> claim = _dataClaimsRepo.GetClaimsLibary();

            string strUserChoice = string.Empty;
            do
            {
                Console.WriteLine($"Next Claim Availalbe: {claim.Peek()}");
                do
                {
                    Console.WriteLine("Do you accept the Claim File y/n");
                    strUserChoice = Console.ReadLine().ToUpper();
                    if (strUserChoice == "y")
                    {
                        Console.WriteLine(claim.Dequeue());
                    }
                } while (strUserChoice != "y" && strUserChoice != "n");
            }
            while (strUserChoice == "n");
        }


        // #3 Input Claims
        public void NewClaim()
        {
            Console.Clear();
            ClaimLibary newData = new ClaimLibary();

            //Claim ID
            Console.WriteLine("Enter Claim Number");
            string ClaimID = Console.ReadLine();
            newData.ClaimID = int.Parse(ClaimID);

            //ClaimType 
            Console.WriteLine("Enter Claim Type Number:"); 
            newData.ClaimType = Console.ReadLine();

            //Description
            Console.WriteLine("Enter a drief description:");
            newData.Description = Console.ReadLine();

            //Settlement
            Console.WriteLine("Enter settlement amount:");
            string settlement= Console.ReadLine();
            newData.Settlement = double.Parse(settlement);

            //Incident Date
            Console.WriteLine("Enter incident date yy/mm/dd:");
            string incidentDate = Console.ReadLine();
            
            //Claim Date
            Console.WriteLine("Enter incident date yy/mm/dd:");
            string claimDate = Console.ReadLine();
            
            //Valid Claim
            Console.WriteLine("Is the claim Valid?");
            string valid = Console.ReadLine().ToLower();

            if (valid == "y")
            {
                newData.Valid = true;
            }
            else
            {
                newData.Valid = false;
            }

            _dataClaimsRepo.AddDataToList(newData);
        }

        // SEED METHOD
        private void SampleContent()
        {
            ClaimLibary CarAccident = new ClaimLibary(1, "Car", "Car Accident on 465", 400.00, new DateTime(18,04,25), new DateTime(18/04/27), true);
            ClaimLibary HouseFire = new ClaimLibary(2, "Home", "House fire in kitchen", 4000.00, new DateTime(18,04,11), new DateTime(18,04,11), true);
            ClaimLibary PancakeTheft = new ClaimLibary(3, "Theft", "Car Accident on 465", 4.00, new DateTime(18,04,27), new DateTime(18, 04, 27), true);

            _dataClaimsRepo.AddDataToList(CarAccident);
            _dataClaimsRepo.AddDataToList(HouseFire);
            _dataClaimsRepo.AddDataToList(PancakeTheft);

        }
    }
}
