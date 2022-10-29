using System;

namespace Casino
{
    class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w kasynie. ");
            Console.WriteLine("Wpowadź ilość graczy: ");
            string gamers = Console.ReadLine();
            if (int.TryParse(gamers, out int members))
            {
                if (members > 0)
                {
                    Guy[] players = new Guy[members];
                    
                    for (int i = 0; i < players.Length; i++)
                    {
                        players[i] = new Guy();
                        players[i].Cash = random.Next(100, 201);
                        players[i].Name = "Gracz " + (i + 1);
                    }
                    Console.WriteLine("Lista graczy:");
                    for (int i = 0; i < players.Length; i++)
                    {
                        players[i].WriteMyInfo();
                    }
                    Console.WriteLine("Wprowadź prawdopodobieństwo przegranej. Skorzystaj z przecinka.");
                    string probability = Console.ReadLine();

                    if (double.TryParse(probability, out double odds))
                    {
                        while (IsCash(players))
                        {
                            int gamer;
                            gamer = random.Next(1, members + 1);  
                            players[gamer-1].Playing(odds);      
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wprowadź prawidłowe dane. (Być może zastosowałeś '.' zamiast ',')");
                        for (int i = 0; i < players.Length; i++)
                        {
                            Console.WriteLine(players[i].Name + " ma " + players[0].Cash);
                        }
                    }
                    Console.WriteLine("Kasyno zawsze wygrywa");
                }
            }
            else
            {
                Console.WriteLine("Wprowadź poprawną liczbę graczy");
            }
        }
        /// <summary>
        /// Sprawdza czy jeszcze jakiś gracz ma pieniądze
        /// </summary>
        /// <param name="p">Tablica graczy</param>
        /// <returns>Zwraca wartość logiczną w zależności od tego czy jakiś gracz ma jeszcze pieniądze</returns>
        public static bool IsCash(Guy[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].Cash > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}