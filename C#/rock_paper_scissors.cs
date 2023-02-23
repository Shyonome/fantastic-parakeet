using System;

class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int computerChoice;
            while (true) {
                Console.WriteLine("\nDo you choose rock,paper or scissors");
                string userChoice = Console.ReadLine();
                if (userChoice.Equals("rock") || userChoice.Equals("paper") || userChoice.Equals("scissors")) {
                    computerChoice = r.Next(2);
                    switch (computerChoice) {
                        case 0:
                            ComputerChoiceRock(userChoice);
                            break;
                        case 1:
                            ComputerChoicePaper(userChoice);
                            break;
                        case 2:
                            ComputerChoiceScissors(userChoice);
                            break;
                    }
                } else {
                    Console.WriteLine("Wrong input");
                }
            }
        }

        static public void ComputerChoicePaper(string userSelection)
        {
            if (userSelection.Equals("scissors"))
            {
                Console.WriteLine("\nComputer Choice paper");
                Console.WriteLine("You won!! Worray");

            }
            else if (userSelection.Equals("paper"))
            {
                Console.WriteLine("\nComputer Choice {0} as well its, a draw :P", userSelection);
            }
            else
            {
                Console.WriteLine("\nComputer Choice paper", userSelection);
                Console.WriteLine("You lost !! booo");
            }

        }
        static public void ComputerChoiceRock(string userSelection)
        {
            if (userSelection.Equals("paper"))
            {
                Console.WriteLine("\nComputer Choice rock");
                Console.WriteLine("You won!! Worray");

            }
            else if (userSelection.Equals("rock"))
            {
                Console.WriteLine("\nComputer Choice {0} as well its, a draw :P", userSelection);
            }
            else 
            {
                Console.WriteLine("\nComputer Choice rock");
                Console.WriteLine("\nYou lost!! Computer won");
            }
        }
        static public void ComputerChoiceScissors(string userSelection)
        {
            if (userSelection.Equals("rock"))
            {
                Console.WriteLine("\nComputer Choice scissors");
                Console.WriteLine("\nYou won!! Worray");

            }
            else if (userSelection.Equals("rock"))
            {
                Console.WriteLine("\nComputer Choice {0} as well its, a draw :P", userSelection);
            }
            else
            {
                Console.WriteLine("\nComputer Choice paper", userSelection);
                Console.WriteLine("You lost !! booo");
            }

        }
    }