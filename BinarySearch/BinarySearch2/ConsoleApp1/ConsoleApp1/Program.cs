using System;

class Solution
{
    public static long countIter(long n)
    {
        long res = 0;
        long frac = 1;
        long right = n, left;
        do
        {
            left = n / (frac + 1) + 1;
            if (left <= right)
            {
                res += (right - left + 1) * frac;
                right = left - 1;
                frac++;
            }
            else
                break;
        } while (true);
        for (long divisor = 1; divisor <= right; divisor++)
            res += n / divisor;
        return res;
    }
    public static void Main(string[] args)
    {
        long t = Convert.ToInt64(Console.ReadLine());
        long res = Convert.ToInt64(Math.Sqrt(t));
        while (countIter(res) <= t)
            res *= 10;
        long left = res / 10, right = res;
        while (right - left > 1)
        {
            long avg = (left + right) / 2;
            if (countIter(avg) > t)
                right = avg;
            else
                left = avg;
        }
        Console.WriteLine(left.ToString());
    }
}