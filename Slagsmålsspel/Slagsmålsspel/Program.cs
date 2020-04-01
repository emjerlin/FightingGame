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

            /*
           int HP = 0;
           int restart = 0;
           int balance = 0;

           while (restart < 1)
           {
               while (HP <= 100) //när HP användaren väljer är mindre än 100 kommer den fortsätta att fråga, för att man inte ska kunna välja HP som är under 100
               {
                   Console.WriteLine("Choose how much HP you would like the champions to have! (minimum 100)");
                   string HPstring = Console.ReadLine();
                   bool success = int.TryParse(HPstring, out HP);
               }
               */


            string[] champion = { "Pikachu", "Princess Peach", "Sonic", "Kirby" };
            int[] championHP = { 50, 65, 45, 40 };

            int repeat = 0;
            while (repeat == 0)
            {
                Console.Clear();
                Console.WriteLine("Choose your fighter. By picking a fighter, you can then see it's HP, average damage and attacks before confirming your selection:");

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(champion[i]);
                }

                string champSelect = Console.ReadLine();

                int chosenChamp = compareChamp(champSelect);

                Console.WriteLine("You have chosen " + champion[chosenChamp] + ". This champion has " + championHP[chosenChamp] + "HP and does an average of " + " damage");

                int response = 0;

                while (response == 0)
                {

                    Console.WriteLine("Do you want to confirm this selection? (y/n)");

                    string confirm = Console.ReadLine();

                    if (confirm == "y")
                    {
                        repeat++;
                        response++;
                    }
                    else if (confirm == "n")
                    {
                        Console.WriteLine("You're being sent back to champion select");
                        response++;
                        loading();
                    }
                    else
                    {
                        Console.WriteLine("Please answer y/n to confirm or deny your champion selection");
                    }
                }
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

            Console.WriteLine("End");

            Console.ReadLine();

            Console.WriteLine("Would you like to play again? y/n");

            string playagain = Console.ReadLine();

            if (playagain != "y") // när man inte svarar ja, läggs det till en till variabeln restart, och while loopen startas inte om och spelet börjar inte om. Om man skriver y kommer loopen (hela spelet) att startas om
            {
                restart++;
            }


            Console.WriteLine("Thanks for playing!");
           */
        }

        static int compareChamp(string champSelect)
        {
            string[] champion = { "Pikachu", "Princess Peach", "Sonic", "Kirby" };

            int champNumber= 0;

            for (int i = 0; i < 4; i++)
            {
                if (champSelect == champion[i])
                {
                    champNumber = i;
                }
            }
            return champNumber;

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





