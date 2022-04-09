using System;
using System.Collections;
using System.Collections.Generic;

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

        long winnings = 0;
        int Jcount = 0;

        Random rnd = new Random();

        public long won() { return winnings; }
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

            if (reel1[ind[0]] == reel2[ind[1]] && reel2[ind[1]] == reel3[ind[2]])
            {
                switch (reel1[ind[0]])
                {
                    case 2:
                        winnings += 10 * bet;
                        break;
                    case 3:
                        winnings += 20 * bet;
                        break;
                    case 4:
                        winnings += 30 * bet;
                        break;
                    case 5:
                    case 6:
                        winnings += 40 * bet;
                        break;
                    case 1:
                        Console.WriteLine(++Jcount);
                        winnings += 100 * bet;
                        break;
                }
            }
            else
            {
                int cnt = (reel1[ind[0]] == 1 ? 1 : 0) + (reel2[ind[1]] == 1 ? 1 : 0) + (reel3[ind[2]] == 1 ? 1 : 0);
                if (cnt == 2) winnings += 5 * bet;
                else if (cnt == 1) winnings += 1 * bet;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int bet = 1;
            Reels reels = new Reels("test.txt");
            for (int i = 0; i < 1000000; i++)
            {
                reels.spin(bet);
            }

            Console.WriteLine(1.0 * reels.won() / (1000000*bet));

        }
    }
}