using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SomeTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"1 - Ja wymyślę liczbę, a ty zgadniesz.");
                Console.WriteLine($"2 - Ty wymyślisz liczbę, a ja zgadnę.");
                Console.WriteLine($"0 - Koniec programu.");
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.Clear();
                            PlayerGuessingNumber();
                            break;
                        }
                        case 2:
                        {
                            Console.Clear();
                            AIGuessingNumber();
                            break;
                        }
                }

            } while (input != 0);
            Console.WriteLine("Program zakończony.");
        }

        private static void AIGuessingNumber()
        {
            int minNumber = 1;
            int maxNumber = 100;

            int aiGuess = maxNumber / 2;

            Console.WriteLine($"Pomyśl jakąś liczbę z zakresu {minNumber} - {maxNumber}...");
            Console.WriteLine($"Jeśli liczba, którą ci podam będzie większa, wpisz 1...");
            Console.WriteLine($"A jeśli będzie mniejsza wpisz 2...");
            Console.WriteLine($"Natomias jeśli odgadnę, wpisz 0...");

            int input = -1;
            int counter = 0;

            do
            {
                Console.WriteLine($"Myślę, że twoja liczba to {aiGuess}. Czy mam rację?");
                counter++;
                input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    maxNumber = aiGuess;
                    aiGuess = (minNumber + maxNumber) / 2;
                    Console.WriteLine("Aj... za dużo...");
                }
                if (input == 2)
                {
                    minNumber = aiGuess;
                    aiGuess = (minNumber + maxNumber) / 2;
                    Console.WriteLine("Oj oj oj... za mało...");
                }

            } while (input != 0);
            Console.WriteLine($"ZGADŁEM! Twoja liczba to {aiGuess}! Zajęło mi to tylko {counter} prób!");
            Console.WriteLine("Klikij 'ENTER' aby kontunuować...");
            Console.ReadLine();
        }

        private static void PlayerGuessingNumber()
        {
            int minNumber = 1;
            int maxNumber = 100;
            int attemptsToHint = 4;

            Random random = new Random();
            int numberToGuess = random.Next(1, maxNumber + 1);
            int yourNumber = 0;
            int counter = 0;

            bool isGameEnd = false;

            Console.WriteLine(numberToGuess);
            do
            {
                Console.WriteLine($"Zgadnij o jakiej liczbie myślę... (z zakresu {minNumber} - {maxNumber}");
                if (counter >= 4)
                {
                    Console.WriteLine($"Jeśli chcesz się poddać, wpisz 0...");
                }
                yourNumber = Convert.ToInt32(Console.ReadLine());
                counter++;

                if (yourNumber < numberToGuess && yourNumber != 0)
                {
                    Console.WriteLine($"Podana liczba jest za mała...\n");
                }
                if (yourNumber > numberToGuess)
                {
                    Console.WriteLine($"Podana liczba jest za duża...\n");
                }

                if (yourNumber == numberToGuess || yourNumber == 0)
                {
                    isGameEnd = true;
                }

            } while (!isGameEnd);

            if (yourNumber == numberToGuess)
            {
                Console.WriteLine($"Brawo, odgadłeś liczbę za {counter} razem!");
            }
            else
            {
                Console.WriteLine($"Próbowałeś {counter - 1} razy i poddałeś się. Może następnym razem ci się poszczęści...");
            }
            Console.WriteLine("Klikij 'ENTER' aby kontunuować...");
            Console.ReadLine();
        }
    }
}
