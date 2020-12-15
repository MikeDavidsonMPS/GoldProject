using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKomClaim
{
    class ClaimDisplayUI
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
                        InputNewClaim();
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
        private void DisplayClaims()
        {
            Console.Clear();

            List<ClaimLibary> listOfData = _dataClaimRepo.GetClaimLibary();

            foreach (ClaimLibary data in listOfData)
            {
                Console.WriteLine($"{data.ClaimID}, { }, {data.TypeOfClaim}, { },  {data.Description}, { }, {data.Settlement}, { }, {data.IncidentMonth}, $" / ", {data.IncidentDay}, $" / ", {data.IncidentYear}, { }, {data.ClaimMonth}, $" / ", {data.ClaimDay}, $" / ", { data.ClaimYear}");
            }
        }


        // #2 ASSIGN CLAIM
        private void DisplayContentByTitle()
        {
            Console.Clear();
       
            //Frist in first out
            ClaimLibary data = _dataClaimRepo.GetdDataByClaimID(claimID); //wrong


            Queue<string> firstInFirstOut = new Queue<string>();        //wrong
            firstInFirstOut.Enqueue("Luke")

            //Display said content if it isn't null
            if (data != null)                                           //wrong
            {
                Console.WriteLine($"ClaimID: {data.ClaimID}, \n" +
                    $"Type: {data.TypeOfClaim}\n" +
                    $"Description: {data.Description}\n" +
                    $"Amount: {data.Settlement}\n" +
                    $"Date of Incident: {data.IncidentDate}\n" +
                    $"Date of Claim: {data.Claim}\n" +
                    $"Is Claim Valid: {data.Valid}");
            }
            else
            
            Console.WriteLine("is this the correct claim Y/N?");
             string fristClaim = Console.ReadLine().ToLower();
          
            if (fristClaim == "y")                                 // this wrong
            {
                data.fristClaim = true;
            }
            else
            {
                data.ClaimsTermial = false;
            }
            if(fristClaim == "n")
            {
                return.ClaimsTermial;                            // this wrong
            }
        }


        // #3 Input Claims
        private void InputNewClaim()
        {
            Console.Clear();
            ClaimLibary newData = new ClaimLibary();

            //Claim ID
            Console.WriteLine("Enter Claim Number");
            newData.Title = Console.ReadLine();

            // EMUN: ClaimType 
            Console.WriteLine("Enter Claim Type Number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            string claimTypeAsString = Console.ReadLine();             
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newData.TypeOfClaim = (ClaimTypes)claimTypeAsInt;

            //Description
            Console.WriteLine("Enter the rating for the content (G, PG, PG-13, etc):");
            newData.Description = Console.ReadLine();

            //Settlement
            Console.WriteLine("Enter settlement amount:");
            string settlement= Console.ReadLine();
            newData.Settlement = double.Parse(settlement);

            //Incident Date
            Console.WriteLine("Enter incident date mm/dd/yy:");
            string incidentDate = Console.ReadLine();

            //Claim Date
            Console.WriteLine("Enter incident date mm/dd/yy:");
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

            _dataClaimRepo.AddDataToList(newData);
        }

        // SEED METHOD
        private void SampleContent()
        {
            ClaimLibary CarAccident = new ClaimLibary(1, ClaimType.Car, "Car Accident on 465", 400, .00,  4"/"25"/"18, 4"/"27"/"18, true);
            ClaimLibary HouseFire = new ClaimLibary(2, ClaimType.Home, "House fire in kitchen", 4000, .00, 4"/"11"/"18, 4"/"12"/"18, true);
            ClaimLibary PancakeTheft = new ClaimLibary(3, ClaimType.Theft, "Car Accident on 465", 4, .00, 4"/"27"/"18, 4"/"27"/"18, true);

            _dataClaimRepo.AddDataToList(CarAccident);
            _dataClaimRepo.AddDateToList(HouseFire);
            _dataClaimRepo.AddDateToList(PancakeTheft);

        }
    }
}
