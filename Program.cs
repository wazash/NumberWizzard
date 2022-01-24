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
                // Czyszczenie konsoli po rozpoczęciu pętli
                Console.Clear();

                // Wyświetlenie wiadomości
                Console.WriteLine($"1 - Ja wymyślę liczbę, a ty zgadniesz.");
                Console.WriteLine($"2 - Ty wymyślisz liczbę, a ja zgadnę.");
                Console.WriteLine($"0 - Koniec programu.");

                // Pobranie informacji od gracza, którą wersję gry chce zagrać
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            // Jeśli '1' włącz wersję, gdzie gracz zgaduje liczbę
                            Console.Clear();
                            PlayerGuessingNumber();
                            break;
                        }
                        case 2:
                        {
                            // Jeśli '2' włącz wersję, gdzie AI zgaduje liczbę
                            Console.Clear();
                            AIGuessingNumber();
                            break;
                        }
                }

            } while (input != 0); // Jeśli '0' zakończ program
            Console.WriteLine("Program zakończony.");
        }

        private static void AIGuessingNumber()
        {
            // Ustawienie przedziału liczbowego
            int minNumber = 1;
            int maxNumber = 100;

            // Ustawienie pierwszego strzału
            int aiGuess = maxNumber / 2;

            // Wypisanie informacji (instrukcji)
            Console.WriteLine($"Pomyśl jakąś liczbę z zakresu {minNumber} - {maxNumber}...");
            Console.WriteLine($"Jeśli liczba, którą ci podam będzie większa, kliknij strzałkę w górę (UpArrow)...");
            Console.WriteLine($"A jeśli będzie mniejsza wpisz kliknij strzałkę w dół (DownArrow)...");
            Console.WriteLine($"Natomias jeśli odgadnę, wciśnij ENTER...");

            // Licznik prób
            int counter = 0;

            // Zmienna przechowująca informację o klawiszu
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine($"Myślę, że twoja liczba to {aiGuess}. Czy mam rację?");
                counter++;
                
                // 'Nasłuchiwanie' klawisza
                key = Console.ReadKey();

                // Jeśli twoja liczba była mniejsza niż podana przez AI wciśnij strzałkę w górę
                if (key.Key == ConsoleKey.UpArrow) 
                {
                    maxNumber = aiGuess;
                    aiGuess = (minNumber + maxNumber) / 2;
                    Console.WriteLine("Aj... za dużo...");
                }
                // Jeśli twoja liczba była większa niż podana przez AI wciśnij strzałkę w dół
                if (key.Key == ConsoleKey.DownArrow)
                {
                    minNumber = aiGuess;
                    aiGuess = (minNumber + maxNumber) / 2;
                    Console.WriteLine("Oj oj oj... za mało...");
                }

            } while (key.Key != ConsoleKey.Enter); // Jeśli AI zgadło wciśnij ENTER
            Console.WriteLine($"ZGADŁEM! Twoja liczba to {aiGuess}! Zajęło mi to tylko {counter} prób!");
            Console.WriteLine("Klikij 'ENTER' aby kontunuować...");
            Console.ReadLine();
        }

        private static void PlayerGuessingNumber()
        {
            // Ustawienie przedziału liczbowego
            int minNumber = 1;
            int maxNumber = 100;
            // Po ilu próbach ma wyświetlić się podpowiedź jak się poddać
            int attemptsToHint = 4;
            // Losowanie liczby, którą musisz zgadnąć
            Random random = new Random();
            int numberToGuess = random.Next(1, maxNumber + 1);

            int yourNumber = 0;
            int counter = 0;
            
            // Zmienna przechoowująca informację o stanie gry (czy gra się skończyła)
            bool isGameEnd = false;
            
            // Wypisanie wylosowanej liczby, żeby sprawdzić czy komputer nie oszukuje
            // Console.WriteLine(numberToGuess);
            do
            {
                Console.WriteLine($"Zgadnij o jakiej liczbie myślę... (z zakresu {minNumber} - {maxNumber}");
                // Wypisanie podpowiedzi po odpowiedniej liczbie prób
                if (counter >= attemptsToHint)
                {
                    Console.WriteLine($"Jeśli chcesz się poddać, wpisz 0...");
                }
                // Pobranie liczby od gracza
                yourNumber = Convert.ToInt32(Console.ReadLine());

                // Zwiększenie licznika prób
                counter++;

                // Warunek sprawdzający, czy twoja liczba jest mniejsza niż ta do odgadnięcia
                if (yourNumber < numberToGuess && yourNumber != 0)
                {
                    Console.WriteLine($"Podana liczba jest za mała...\n");
                }
                // Warunek sprawdzający, czy twoja liczba jest większa niż ta do odgadnięcia
                if (yourNumber > numberToGuess)
                {
                    Console.WriteLine($"Podana liczba jest za duża...\n");
                }

                // Jeśli podana liczba jest taka sama jak ta do odgadnięcia, ustaw stan gry na zakończony
                if (yourNumber == numberToGuess || yourNumber == 0)
                {
                    isGameEnd = true;
                }

            } while (!isGameEnd); // Powtarzaj dopóki gra się nie zakończy

            // Wypisywanie informacji po zakończeniu gry
            if (yourNumber == numberToGuess)
            {
                // Jeśli zgadłeś za pierwszym NIESAMOWITA informacja
                if(counter == 1)
                {
                    Console.WriteLine($"NIESAMOWITE! ZGADŁEŚ ZA PIERWSZYM RAZEM! Możesz kupić sobie puchar :)");
                }
                // Jeśli miałeś mniej niż 10 prób normalna informacja
                else if(counter > 1 && counter < 10)
                {
                    Console.WriteLine($"Brawo, odgadłeś liczbę za {counter} razem!");
                }
                // Jeśli miałeś więcej niż 10 prób słaba informacja
                else
                {
                    Console.WriteLine($"Noooo, trochę ci to zajęło. Odgałeś za {counter} razem.");
                }
            }
            // Jeśli się poddałeś, no cóż...
            else
            {
                Console.WriteLine($"Próbowałeś {counter - 1} razy i poddałeś się. Może następnym razem ci się poszczęści...");
            }
            Console.WriteLine("Klikij 'ENTER' aby kontunuować...");
            Console.ReadLine();
        }
    }
}
