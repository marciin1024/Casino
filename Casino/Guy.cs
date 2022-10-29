using System;
using System.Collections.Generic;
using System.Text;

namespace Casino
{
    class Guy
    {
        public string Name;
        public int Cash;
        Random random = new Random();
        /// <summary>
        /// Wyświetla w konsoli imię i posiadaną kwotę.
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " ma " + Cash + " zł.");
        }
        /// <summary>
        /// Przekazuje pieniądze i usuwa je z portfela (lub wyświetla w konsoli
        /// komunikat o braku środków)
        /// </summary>
        /// <param name="amount">Przekazywana kwota.</param>
        /// <returns>Ilość pieniędzy wyjmowanych z portfela lub 0, jeśli 
        /// dostępne środki są za małe(lub parametr amount jest nieprawidłowy).</returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " mówi: " + amount + " nie jest poprawną kwotą.");
                return 0;
            }
            if (amount > Cash)
            {
                Console.WriteLine(Name + " mówi: nie mam wystarczających środków, aby dać Ci " + amount + " zł.");
                return 0;
            }
            Cash -= amount;
            return amount;
        }
        /// <summary>
        /// Przyjmuje pieniądze i dodaje je do portfela(lub wyświetla w konsoli
        /// komunikat o nieprawidłowej kwocie).
        /// </summary>
        /// <param name="amount">Przyjmowana kwota.</param>
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " mówi: nie przyjmę " + amount + "zł.");
            }
            else
            {
                Cash += amount;
            }
        }
        /// <summary>
        /// Odpowiada za przebieg gry w kasynie
        /// </summary>
        /// <param name="odds">Prawdopodobieństwo przegranej</param>
        public void Playing(double odds)
        {
            if (Cash > 0)
            {
                Console.WriteLine("\nTeraz gra: " + Name);
                WriteMyInfo();
                Console.WriteLine("Prawdopodobieństwo przegranej wynosi: " + odds + ". Stawiana kwota: ");
                string howMuch = Console.ReadLine();
                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = GiveCash(amount) * 2;
                    if (pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            ReceiveCash(pot);
                            Console.WriteLine("Wygrałeś " + pot + "zł!!!!!");
                        }
                        else
                        {
                            Console.WriteLine("Niestety, przegrałeś.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wprowadź poprawną kwotę.");
                }
            }
        }
    }
}
