using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

/*
ID  NAME
1   Gustavo
2   Sombrero
3   Batak
4   Kofica
5   Petao
6   Kokska
 */

namespace Test
{
    class Reels
    {
        public const int GUSTAVO = 1;
        public const int SOMBRERO = 2;
        public const int BATAK = 3;
        public const int KOFICA = 4;
        public const int PETAO = 5;
        public const int KOKOSKA = 6;

        private int[]? reel1;
        private int[]? reel2;
        private int[]? reel3;

        long winnings = 1000;
        int Jcount = 0;

        Random rnd = new Random();

        public long won() { return winnings; }
        public void bet(int bet) { winnings -= bet; }
        public Reels(string fname)
        {

            using (StreamReader sr = new StreamReader(fname))
            {
                string[] elems;

                elems = sr.ReadLine().Split(' ');

                for (int j = 0; j < elems.Length; j++)
                {
                    if (j == 0) reel1 = new int[int.Parse(elems[j])];
                    else reel1[j - 1] = int.Parse(elems[j]);
                }

                elems = sr.ReadLine().Split(' ');
                for (int j = 0; j < elems.Length; j++)
                {
                    if (j == 0) reel2 = new int[int.Parse(elems[j])];
                    else reel2[j - 1] = int.Parse(elems[j]);
                }

                elems = sr.ReadLine().Split(' ');
                for (int j = 0; j < elems.Length; j++)
                {
                    if (j == 0) reel3 = new int[int.Parse(elems[j])];
                    else reel3[j - 1] = int.Parse(elems[j]);
                }
            }
        }

        public void spin(int bet)
        {
            if (reel1 == null || reel2 == null || reel3 == null) return;
            int[] ind = { rnd.Next(0, reel1.Length), rnd.Next(0, reel2.Length), rnd.Next(0, reel3.Length) };

            Console.WriteLine("\nMAIN LINE: ");
            Console.WriteLine("{0}  {1}  {2} " ,reel1[ind[0]] , reel2[ind[1]] , reel3[ind[2]]);

            if (reel1[ind[0]] == reel2[ind[1]] && reel2[ind[1]] == reel3[ind[2]])
            {
                switch (reel1[ind[0]])
                {
                    case 2:
                        winnings += 10 * bet;
                        Console.WriteLine("You won: 10 x bet!");
                        break;
                    case 3:
                        winnings += 20 * bet;
                        Console.WriteLine("You won: 20 x bet!");
                        break;
                    case 4:
                        winnings += 30 * bet;
                        Console.WriteLine("You won: 30 x bet!");
                        break;
                    case 5:
                    case 6:
                        winnings += 40 * bet;
                        Console.WriteLine("You won: 40 x bet!");
                        break;
                    case 1:
                        //Console.WriteLine(++Jcount);
                        Console.WriteLine("You won: JACKPOT!! 100 x bet");
                        winnings += 100 * bet;
                        break;
                }
            }
            else
            {
                int cnt = (reel1[ind[0]] == 1 ? 1 : 0) + (reel2[ind[1]] == 1 ? 1 : 0) + (reel3[ind[2]] == 1 ? 1 : 0);
                if (cnt == 2) { winnings += 5 * bet; Console.WriteLine("You won: 5 x bet!"); }
                else if (cnt == 1) { winnings += 1 * bet; Console.WriteLine("You won: 1 x bet!"); }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(170, 30);
            Console.Title = "LOS POLLOS HERMANOS";

            //    _       ___    ___     ___    ___    _      _       ___    ___     _  _   ___   ___   __  __     _     _  _    ___    ___ 
            //   | |     / _ \  / __|   | _ \  / _ \  | |    | |     / _ \  / __|   | || | | __| | _ \ |  \/  |   /_\   | \| |  / _ \  / __|
            //   | |__  | (_) | \__ \   |  _/ | (_) | | |__  | |__  | (_) | \__ \   | __ | | _|  |   / | |\/| |  / _ \  | .` | | (_) | \__ \
            //   |____|  \___/  |___/   |_|    \___/  |____| |____|  \___/  |___/   |_||_| |___| |_|_\ |_|  |_| /_/ \_\ |_|\_|  \___/  |___/
            //                                                                                                                              


     

            // Console.SetCursorPosition(0, Console.CursorTop - 1); Console.WriteLine("JEL RADI" );

            string line;
           // string ;
            int bet;
            int input;
            //int credits = 1000;
            Reels reels = new Reels("test.txt");
            string logo = @"
                _       ___    ___     ___    ___    _      _       ___    ___     _  _   ___   ___   __  __     _     _  _    ___    ___ 
               | |     / _ \  / __|   | _ \  / _ \  | |    | |     / _ \  / __|   | || | | __| | _ \ |  \/  |   /_\   | \| |  / _ \  / __|
               | |__  | (_) | \__ \   |  _/ | (_) | | |__  | |__  | (_) | \__ \   | __ | | _|  |   / | |\/| |  / _ \  | .` | | (_) | \__ \
               |____|  \___/  |___/   |_|    \___/  |____| |____|  \___/  |___/   |_||_| |___| |_|_\ |_|  |_| /_/ \_\ |_|\_|  \___/  |___/
                                                                                                                                          
";
            Console.WriteLine(logo);
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("=========\n");
            Console.WriteLine("TO START THE GAME PRESS 1\n" +
                "TO EXIT PRESS -1\n");

            //Console.WriteLine(line);

            while ((line = Console.ReadLine()) != "1") {

                Console.WriteLine("TO START THE GAME PRESS 1");

            }


            while (true)
            {
                if (reels.won() == 0 ) { Console.WriteLine("GAME OVER!\n OUT OF CREDITS!" ); break; }

                Console.WriteLine("Current credits: " + reels.won());
                Console.WriteLine("Place your bet! " );

                line = Console.ReadLine();
                try
                {
                    bet = int.Parse(line);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid bet! Try again!");
                    continue;
                }
                
                if ((bet < 0 && bet!=-1)  || bet==null) {
                    Console.WriteLine("Invalid bet! Try again!");
                    continue;
                }
                if (bet > reels.won()) {
                    Console.WriteLine("Not enough credits! Try again!");
                    continue;
                }
                if (bet == -1)
                {
                    Console.WriteLine("Thanks for playing in our casino");
                    Thread.Sleep(1500);

                    break;
                }
                reels.bet(bet);
                reels.spin(bet);

                


            }
















            /*
            int bet = 1;
            Reels reels = new Reels("test.txt");
            for (int i = 0; i < 10000; i++)
            {
                reels.spin(bet);
            }
            Console.WriteLine(1.0 * reels.won() / (10000 * bet));
            */

        }
    }
}