using System;
using System.Threading;
namespace FlappyBird
{
    class Program
    {

        static int palyaMagassag = 20;
        static int palyaSzelesseg = 60;

        static double madarY = 10;
        static double gravitacio = 0.2;
        static double lendulet = 0;

        static int csoX = 50;
        static int resMagassag = 7;
        static int resPozicio = 5;
        static int pontszam = 0;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Flappy Bird";

            try
            {
                Console.SetWindowSize(palyaSzelesseg + 1, palyaMagassag + 2);
                Console.SetBufferSize(palyaSzelesseg + 1, palyaMagassag + 2);
            }
            catch { }

            while (true)
            {

                madarY = 10;
                lendulet = 0;
                csoX = 50;
                resPozicio = rnd.Next(2, palyaMagassag - resMagassag - 2);
                pontszam = 0;

                bool jatekFut = true;

                while (jatekFut)
                {
                    if (Console.KeyAvailable)
                    {
                        var gomb = Console.ReadKey(true).Key;
                        if (gomb == ConsoleKey.Spacebar)
                        {
                            lendulet = -1.5;
                        }
                    }

                    lendulet += gravitacio;
                    madarY += lendulet;
                    csoX--;

                    if (csoX < 1)
                    {
                        csoX = palyaSzelesseg - 5;
                        resPozicio = rnd.Next(2, palyaMagassag - resMagassag - 2);
                        pontszam++;
                    }

                    bool utkozes = false;
                    if (madarY < 0 || madarY >= palyaMagassag) utkozes = true;

                    if (csoX == 10)
                    {
                        if (madarY < resPozicio || madarY > resPozicio + resMagassag)
                            utkozes = true;
                    }

                    if (utkozes)
                    {
                        jatekFut = false;
                        break;
                    }

                    Console.Clear();

                    for (int i = 0; i < palyaMagassag; i++)
                    {
                        if (i < resPozicio || i > resPozicio + resMagassag)
                        {
                            Console.SetCursorPosition(csoX, i);
                            Console.Write("█");
                        }
                    }

                    Console.SetCursorPosition(10, (int)madarY);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(">");
                    Console.ResetColor();

                    Console.SetCursorPosition(0, 0);
                    Console.Write($"Pontszám: {pontszam}");

                    Thread.Sleep(50);
                }


                Console.Clear();
                Console.SetCursorPosition(palyaSzelesseg / 4, palyaMagassag / 2);
                Console.WriteLine($"Vége a játéknak! Pontjaid: {pontszam}");
                Console.SetCursorPosition(palyaSzelesseg / 4, (palyaMagassag / 2) + 1);
                Console.WriteLine("R = újraindítás | ESC = kilépés");

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                    break;


            }
        }
    }
}
