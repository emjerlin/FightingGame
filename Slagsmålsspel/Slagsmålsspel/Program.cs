using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slagsmålsspel
{
    class Program
    {

        static void Main(string[] args)
        {

            int wins = 0;

            Console.WriteLine("Welcome to Ultimate Smash Bros! Here, you will battle to get glory and fame! Please write your name to set up your account!");
            string name = Console.ReadLine();
            Console.WriteLine("Greetings " + name + ". Enjoy your stay and your future battles. We're starting up the game");

            loading();

            int restart = 0;

            int chosenChamp = 0;
            while (restart < 1) //håller igång spelet tills n skrivs i slutet och då spelet avslutas , restart ökar med 1 och uppfyller inte kraven längre
            {


                string[] champion = { "Invalid character", "Pikachu", "Princess Peach", "Sonic", "Kirby" };
                int[] championHP = { 0, 140, 154, 120, 100 };
                int[] average = { 0, 20, 23, 31, 30 };



                int repeatChampSelect = 0;
                while (repeatChampSelect == 0)
                {
                    int invalidChampion = 0;
                    while (invalidChampion == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Choose your fighter. By picking a fighter, you can then see it's HP and average damage before confirming your selection:");
                        Console.WriteLine("Your current total wins are " + wins + "!");
                        Console.WriteLine();

                        for (int i = 1; i < 5; i++)
                        {
                            Console.WriteLine(champion[i]);
                        } //skriver ut karaktärerna i arrayen förutom den första med index 0 då detta är för att kompensera för om personen skriver en ogiltig karaktär. 
                        //jag använder en for loop för det är samma procedur som ska ske flera gånger, och då istället för att skriva samma writeline 4 gånger med en liten förändring har jag skrivit det i en for loop istället.

                        string champSelect = Console.ReadLine();
                        Console.WriteLine();

                        chosenChamp = compareChamp(champSelect);

                        if (chosenChamp == 0)
                        {
                            Console.WriteLine("Please choose a character from the list!");
                            loading();
                        }
                        else
                        {
                            Console.WriteLine("You have chosen " + champion[chosenChamp] + ". This champion has " + championHP[chosenChamp] + " HP and does an average of " + average[chosenChamp] + " damage");
                            invalidChampion++;
                        }
                    }

                    int confirmRepeat = 0;

                    while (confirmRepeat == 0)
                    {

                        Console.WriteLine("Do you want to confirm this selection? (y/n)");

                        string confirm = Console.ReadLine();
                        Console.WriteLine();

                        if (confirm == "y")
                        {
                            repeatChampSelect++;
                            confirmRepeat++;
                        }
                        else if (confirm == "n")
                        {
                            Console.WriteLine("You're being sent back to champion select");
                            confirmRepeat++;
                            loading();
                        }
                        else
                        {
                            Console.WriteLine("Please answer y/n to confirm or deny your champion selection");
                        }
                    }
                }


                Console.WriteLine("The match is starting... Searching for an opponent...");
                loading();
                Console.Clear();
                int enemy = enemyGenerator();

                // match is starting 

                Console.WriteLine("Enemy found! You are meeting " + champion[enemy] + " in battle. They have " + championHP[enemy] + " HP and does an average of " + average[enemy] + " damage. Good luck...");


                int yourHP = championHP[chosenChamp];
                int enemyHP = championHP[enemy];

                loading();

                while (enemyHP > 0 && yourHP > 0)
                {
                    Console.Clear();

                    Random Generator = new Random(); // random generator för både om slaget träffar men också vilken action enemien använder

                    int actionChoose = 0;

                    while (actionChoose == 0)
                    {

                        Console.WriteLine("It's your turn:        Attack: A        Heal: H");
                        string actionWrite = Console.ReadLine();
                        string action = actionWrite.ToLower();


                       
                        if (action == "a")
                        {
                            int hit = Generator.Next(0, 5);
                            if (hit >= 1)
                            {
                                int amountDMG = attack(chosenChamp);
                                Console.WriteLine(champion[chosenChamp] + " hits " + champion[enemy] + " for " + amountDMG + " damage!");

                                enemyHP -= amountDMG;
                                Console.WriteLine("Your opponent is down to " + enemyHP + " HP");

                            }
                            else
                            {
                                Console.WriteLine("You tried to attack, but missed!");
                                Console.WriteLine("Your opponent has " + enemyHP + " HP left");
                            }
                            actionChoose++;

                        }
                        if (action == "h")
                        {
                            int amountHeal = attack(enemy);
                            Console.WriteLine("You healed from " + yourHP + " to " + (yourHP + amountHeal) + " HP");
                            yourHP += amountHeal;
                            actionChoose++;
                        }

                        if (action != "a" && action != "h")
                        {
                            Console.Clear();
                            Console.WriteLine("Choose from the following actions, please");
                        }
                    }

                    Console.WriteLine("It's the enemies turn. They're picking their action");
                    loading();
                    Console.WriteLine();

                    int enemyAction = Generator.Next(1, 6);

                    if (enemyAction <= 3)
                    {
                        int hit = Generator.Next(0, 5);
                        if (hit >= 1)
                        {
                            int amountDMG = attack(enemy);
                            Console.WriteLine(champion[enemy] + " hits " + champion[chosenChamp] + " for " + amountDMG + " damage!");

                            yourHP -= amountDMG;
                            Console.WriteLine("You are down to " + yourHP + " HP");
                        }
                        else
                        {
                            Console.WriteLine("The enemy tried to attack, but missed!");
                            Console.WriteLine("You have " + yourHP +" HP left");
                        }
                    }
                    if (enemyAction > 3)
                    {
                        int amountHeal = attack(chosenChamp);
                        Console.WriteLine("They healed from " + enemyHP + " to " + (enemyHP + amountHeal) + " HP");
                        enemyHP += amountHeal;
                    }
                    Console.WriteLine("Press enter");
                    Console.ReadLine();

                }
                if (enemyHP <= 0)
                {
                    Console.WriteLine("You won! Claim your price!");
                    wins++;
                    Console.WriteLine("Your current total wins are " + wins + "!");
                }
                else if (yourHP <= 0)
                {
                    Console.WriteLine("You lost...You won't be getting a pocal this time");
                    Console.WriteLine("Your current total wins are " + wins + "!");
                }
                //match is over



                Console.WriteLine("Would you like to play again? y/n");

                string playagain = Console.ReadLine();

                if (playagain != "y") // när man inte svarar ja, läggs det till en till variabeln restart, och while loopen startas inte om och spelet börjar inte om. Om man skriver y kommer loopen (hela spelet) att startas om
                {
                    restart++;
                }
            }
            Console.WriteLine("Thanks for playing " + name + "! You're being logged out");
            loading();
        }


        static int compareChamp(string champSelect)

        {
            string champSelectLow = champSelect.ToLower();
            string champSelectCompact = champSelectLow.Trim();


            string[] champion = { "Invalid character", "pikachu", "princess peach", "sonic", "kirby", };

            int champNumber = 0;

            for (int i = 1; i < 5; i++)
            {
                if (champSelectCompact == champion[i])
                {
                    champNumber = i;
                }

            }


            return champNumber;

        }
        static int enemyGenerator()
        {
            string[] champion = { "Invalid Character", "Pikachu", "Princess Peach", "Sonic", "Kirby" };

            Random Generator = new Random();

            int enemy = Generator.Next(1, 5);

            return enemy;

        }


        static int attack(int chosenChamp)
        {

            int r = 0;

            for (int i = 0; i < 4; i++)
            {
                Random generator = new Random();

                if (chosenChamp == 1)
                {
                    r = generator.Next(15, 26);
                }
                else if (chosenChamp == 2)
                {
                    r = generator.Next(10, 36);
                }
                else if (chosenChamp == 3)
                {
                    r = generator.Next(22, 41);
                }
                else if (chosenChamp == 4)
                {
                    r = generator.Next(10, 51);
                }
            }
            return r;
        }
        static void loading()
        {
            string[] dots = { "." };
            for (int i = 0; i <8; i++)
            {
                Console.Write(dots[0]);
                System.Threading.Thread.Sleep(500);

            }
            return;
        }
    }
}





