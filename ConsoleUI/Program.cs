using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


        }
        //I begin by initilizing all the independent variables we'll need.
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();
        private static int winningNumber;
        

        //Here, I create the method GetUserInput, which we'll use later on to automate getting user info
        //It's super simple, it takes in a string as an argument, then writes that and replaces it with
        //what the user enters.
        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            message = Console.ReadLine();
            return message = message.ToLower();
        }

        
        
        //this method generates a random number for us. It takes in two arguements, but these are defined by default
        //we use this later to get random numbers for our raffle function which comes into play during the get info bit
        private static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);

        }

        
        
        //this is the main body of our program, and where the user will spend the most time. I have this set up on the
        //basic premise of a large while loop with nested if and while loops inside, each validating the uniqueness
        //and checking it against the dictionary. it then uses another created method to add each KVP to the dictionary
        
        private static void GetUserInfo()
        {
            string name = "";
            while (name != "yes")
            {
                name = GetUserInput("Please enter guest name");
                raffleNumber = GenerateRandomNumber(min, max);
                if (guests.ContainsValue(name))
                    {
                        while (guests.ContainsValue(name) == true)
                        {
                            name = GetUserInput("Hmm, I think they're already attending. Please enter next guest.");
                        
                        }
                }
                else if (guests.ContainsKey(raffleNumber))
                {
                    while (guests.ContainsKey(raffleNumber) == true)
                    {
                        raffleNumber = GenerateRandomNumber(min, max);
                    }
                }
                
                    AddGuestsInRaffle(raffleNumber, name);
                }

            }
        
        
        //this is a fairly simple method which just writes each guest's name and number
        private static void PrintGuestsName()
        {
            foreach (KeyValuePair<int, string> guest in guests)
                Console.WriteLine(guest);
        }
        
       
        //this method was a little more heady, and needs to be trimmed down. This selects a random number from the
        //options in the dictionary key. it does this by first making a list out of the the keys, then using a random
        //number generator to pick from the length of the list. then, it takes that number into an independent int for
        //later use.
        private static void GetRaffleNumber(Dictionary<int, string> givenDict)
        {
            Random random = new Random();
            List<int> keys = new List<int> { };
            int index = random.Next();
            foreach (KeyValuePair<int, string> guest in guests)
            {
                keys.Add(guest.Key);
            }
            for (int i = 0; i < 1; i++)
            {
                index = random.Next(keys.Count);
            }
            int winningNumber = keys[index];
            
        }


        
        //this is the final method we'll use. It uses values created from other methods to interpolate the message with
        //the Value at the winning raffle number, and then the raffle number.
        private static void PrintWinner()
        {
            Console.WriteLine($"Congratualtions! {(guests[winningNumber])} has won with the number {winningNumber}");
        }
            
       
        
        //this simple method is used in the get info portion to add the validated guests into the dictionary. While I
        //chose to validate in the GetUserInfo method for simplicity, it would've been easy enough to add those lines
        //in here.
        private static void AddGuestsInRaffle(int RaffleNumber, string guest)
        {
            guests.Add(RaffleNumber, guest);
        }


      
       
        //this is the given code to display the animation. If I finish with enough time, I'll swap around some lines
        //to transform it from a pendulum thingy into balloons for the party
        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    
 
        //this is where I'll I'll write out my code using the methods above. We'll start with a message
        //welcoming the guest, then we'll use the GetUserInfo method to run the loop with built in validation
        //after which, we'll use PrintGuestsName to show the user the created Dictionary of names and numbers
        //next we'll use GetRaffleNumber to generate my winning info, which will finally be displayed with
        //PrintWinner followed by either the pendulum or balloons.
        //Other ways to have done this would be to PrintGuestsName after generating the winning info, because
        //they happen independently.
     
    
    

    
    
    
    }
}
