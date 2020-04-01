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

            Console.WriteLine("Welcome to Ultimate Smash Bros! Here, you will battle to get glory, fame, and a bit of coin too! Please write your name to set up your account!");

            string name = Console.ReadLine();
            Console.WriteLine("Greetings " + name + ". Enjoy your stay and your future battles. We're starting up the game");

            loading();
            int restart = 0;

            int chosenChamp = 0;
            while (restart < 1)
            {


                string[] champion = { "Pikachu", "Princess Peach", "Sonic", "Kirby" };
                int[] championHP = { 140, 154, 120, 100 };



                int repeatChampSelect = 0;
                while (repeatChampSelect == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Choose your fighter. By picking a fighter, you can then see it's HP, average damage and attacks before confirming your selection:");

                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine(champion[i]);
                    }

                    string champSelect = Console.ReadLine();

                    chosenChamp = compareChamp(champSelect);


                    Console.WriteLine("You have chosen " + champion[chosenChamp] + ". This champion has " + championHP[chosenChamp] + "HP and does an average of __  damage");

                    int confirmRepeat = 0;

                    while (confirmRepeat == 0)
                    {

                        Console.WriteLine("Do you want to confirm this selection? (y/n)");

                        string confirm = Console.ReadLine();

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
                int enemy = enemyGenerator();
                Console.WriteLine("Enemy found! You are meeting " + champion[enemy] + " in battle. They have " + championHP[enemy] + "HP. Good luck...");


                Random Generator = new Random();
                int hit = Generator.Next(0, 5);
                if (hit >= 1)
                {
                    int amountDMG = attack(chosenChamp);
                    Console.WriteLine(champion[chosenChamp] + " hits " + champion[enemy] + " for " + amountDMG + " damage!");

                    championHP[enemy] = championHP[enemy]-amountDMG;
                    Console.WriteLine("they are down to" + championHP[enemy] + "HP");
                }





                /*
                int StitchHP = HP;

                int AmaliaHP = HP;

                int end = 0;

                while (end != 1)
                {
                    Random Generator = new Random();
                    if (end != 1)
                    {
                        int hit = Generator.Next(0, 5); //genererar ett värde för hit, alltså om attacken träffar
                        int attacks = Generator.Next(1, 30); // genererar ett värde för attacken, alltså hur mycket damage den gör om det träffar

                        if (hit >= 1) //om hit är större eller lika med 1 träffar den
                        {
                            if (AmaliaHP > 0) // om Amalia har mer än 0 hp kommer hon kunna attackera, annars är hon död
                            {

                                Console.WriteLine("Stitch attacks dealing " + attacks + " damage");

                                AmaliaHP = AmaliaHP - attacks;

                                Console.WriteLine("Amalia now has " + AmaliaHP + " hp!");
                            }
                        }
                        else //det som händer om hit är under 1
                        {
                            Console.WriteLine("Stitch missed his attack! Amalia still has " +AmaliaHP +" hp!");
                        }
                        if (AmaliaHP < 0)
                        {
                            Console.WriteLine("Stitch won!");
                            end = end + 1; // lägger till 1 till end, vilket gör att ingen kan attackera längre, utan spelet avslutas istället
                        }

                    }
                    if (end != 1)
                    {
                        int hit = Generator.Next(0, 5);


                        int attacka = Generator.Next(1, 30);
                        Console.ReadLine();

                        if (hit >= 1)
                        {
                            if (StitchHP > 0)
                            {


                                Console.WriteLine("Amalia attacks dealing " + attacka + " damage");

                                StitchHP = StitchHP - attacka;

                                Console.WriteLine("Stitch now has " + StitchHP + " hp!");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Amalia missed his attack! Stitch still has " + StitchHP + " hp!");
                        }
                        if (StitchHP < 0)
                        {
                            Console.WriteLine("Amalia won!");
                            end = end + 1;
                        }
                        Console.ReadLine();
                    }
                }
                */

                Console.WriteLine("End");

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
            string[] champion = { "Pikachu", "Princess Peach", "Sonic", "Kirby" };

            int champNumber = 0;

            for (int i = 0; i < 4; i++)
            {
                if (champSelect == champion[i])
                {
                    champNumber = i;
                }
            }
            return champNumber;

        }
        static int enemyGenerator ()
        {
            string[] champion = { "Pikachu", "Princess Peach", "Sonic", "Kirby" };

            Random Generator = new Random();

            int enemy = Generator.Next(0, 4);

            return enemy;

        }


        static int attack(int chosenChamp)
        {

            int r = 0;

            for (int i = 0; i < 4; i++)
            {
                Random generator = new Random();

                if (chosenChamp == 0)
                {
                    r = generator.Next(15, 26);
                }
                else if (chosenChamp == 1)
                {
                    r = generator.Next(10, 36);
                }
                else if (chosenChamp == 2)
                {
                    r = generator.Next(22, 41);
                }
                else if (chosenChamp == 3)
                {
                    r = generator.Next(10, 51);
                }
            }
            return r;
        }
        static void loading()
        {
            string[] dots = { "." };
            for (int i = 0; i < 5; i++)
            {
                Console.Write(dots[0]);
                System.Threading.Thread.Sleep(500);

            }
            return;
        }
    }
}





