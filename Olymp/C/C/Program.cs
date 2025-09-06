using System;
using System.Collections;

class Program
{
    static int n, k;
    static int[,] grid;

    static void Main()
    {
        var line = Console.ReadLine().Split();
        n = int.Parse(line[0]);
        k = int.Parse(line[1]);
        grid = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            var row = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
                grid[i, j] = int.Parse(row[j]);
        }

        int result = CountColorfulQuadrants();
        Console.WriteLine(result);
    }

    static int CountColorfulQuadrants()
    {
        BitArray[,] nw = new BitArray[n, n];
        BitArray[,] ne = new BitArray[n, n];
        BitArray[,] sw = new BitArray[n, n];
        BitArray[,] se = new BitArray[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                nw[i, j] = new BitArray(k);
                ne[i, j] = new BitArray(k);
                sw[i, j] = new BitArray(k);
                se[i, j] = new BitArray(k);
            }

        for (int i = 1; i < n; i++)
            for (int j = 1; j < n; j++)
            {
                nw[i, j] = (BitArray)nw[i - 1, j].Clone();
                nw[i, j].Or(nw[i, j - 1]);
                nw[i, j].And(Not(nw[i - 1, j - 1]));
                if (grid[i - 1, j - 1] > 0)
                    nw[i, j].Set(grid[i - 1, j - 1], true);
            }

        for (int i = 1; i < n; i++)
            for (int j = n - 2; j >= 0; j--)
            {
                ne[i, j] = (BitArray)ne[i - 1, j].Clone();
                ne[i, j].Or(ne[i, j + 1]);
                ne[i, j].And(Not(ne[i - 1, j + 1]));
                if (grid[i - 1, j + 1] > 0)
                    ne[i, j].Set(grid[i - 1, j + 1], true);
            }

        for (int i = n - 2; i >= 0; i--)
            for (int j = 1; j < n; j++)
            {
                sw[i, j] = (BitArray)sw[i + 1, j].Clone();
                sw[i, j].Or(sw[i, j - 1]);
                sw[i, j].And(Not(sw[i + 1, j - 1]));
                if (grid[i + 1, j - 1] > 0)
                    sw[i, j].Set(grid[i + 1, j - 1], true);
            }

        for (int i = n - 2; i >= 0; i--)
            for (int j = n - 2; j >= 0; j--)
            {
                se[i, j] = (BitArray)se[i + 1, j].Clone();
                se[i, j].Or(se[i, j + 1]);
                se[i, j].And(Not(se[i + 1, j + 1]));
                if (grid[i + 1, j + 1] > 0)
                    se[i, j].Set(grid[i + 1, j + 1], true);
            }

        int count = 0;
        for (int i = 1; i < n - 1; i++)
        {
            for (int j = 1; j < n - 1; j++)
            {
                if (grid[i, j] != 0) continue;

                for (int ca = 0; ca < k; ca++)
                {
                    if (!nw[i, j][ca]) continue;
                    for (int cb = 0; cb < k; cb++)
                    {
                        if (cb == ca || !ne[i, j][cb]) continue;
                        for (int cc = 0; cc < k; cc++)
                        {
                            if (cc == ca || cc == cb || !sw[i, j][cc]) continue;
                            for (int cd = 0; cd < k; cd++)
                            {
                                if (cd == ca || cd == cb || cd == cc || !se[i, j][cd]) continue;
                                count++;
                                goto Next;
                            }
                        }
                    }
                }
            Next:;
            }
        }

        return count;
    }

    static BitArray Not(BitArray bitArray)
    {
        return new BitArray(bitArray).Not();
    }
}
