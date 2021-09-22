using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BlazorCounter.Client.Pages;

public partial class Statistiche
{

    public Random Ran;

    public void Doo()
    {
        int[] Array;
        int[] ArrayToCompare;
        int size = 10;

        Array = new int[size];
        ArrayToCompare = new int[size];
        for (int i = 0; i < size; i++)
            Array[i] = i;

        for (int i = 0; i < size; i++)
            ArrayToCompare[i] = Ran.Next(size);

        int j = 0;
        while (j < int.MaxValue)
        {
            int f = 0;
            for (int i = 0; i < size; i++)
                ArrayToCompare[i] = Ran.Next(size);

            for (int i = 0; i < size; i++)
            {
                if (Array[i] == ArrayToCompare[i])
                    f++;

                if (f == 8)
                    Console.WriteLine("Livello " + f + " (" + j + ")");
                else if (f == 9)
                    Console.WriteLine("Livello " + f + " (" + j + ")");
            }

            if (f == size)
            {
                Console.WriteLine("Trovato dopo " + j + " iterazioni");
                break;
            }
            j++;
        }
    }

    public void Create()
    {
        Ran = new Random();
        Console.WriteLine("Creato");
    }

    public void Rando()
    {
        int num = 7;
        int index = 1;
        int iterazioni = 1;
        while (index < int.MaxValue)
        {
            int n = Ran.Next(100000000);
            if (n == num)
            {
                Console.WriteLine("Trovato dopo " + index + " iterazioni");
                break;
            }

            if (index % 10000000 == 0)
            {
                Console.WriteLine(iterazioni + "0 milioni di iterazioni");
                iterazioni++;
            }
            index++;
        }
    }

    public void Binary()
    {
        int ind = 1;
        int max = 27;
        int iterazioni = 1;
        while (ind < int.MaxValue)
        {
            int f = 0;
            for (int i = 0; i < max; i++)
            {
                if (Ran.NextDouble() > 0.5)
                    f++;
                else
                    break;

                if (f == (max - 2))
                    Console.WriteLine("Livello " + f + "(" + ind + ")");
                else if (f == (max - 1))
                    Console.WriteLine("Livello " + f + "(" + ind + ")");
                else if (f == max)
                    Console.WriteLine("Livello " + f + "(" + ind + ")");
            }
            if (f == max)
            {
                Console.WriteLine("Trovato");
                break;
            }

            if (ind % 10000000 == 0)
            {
                Console.WriteLine(iterazioni + "0 milioni di iterazioni");
                iterazioni++;
            }

            ind++;
        }
    }

    public void RandomValidity()
    {
        int ind = 1;
        double one = 1;
        double two = 1;

        while (ind < int.MaxValue)
        {
            if (Ran.NextDouble() > 0.5)
                one++;
            else
                two++;
            ind++;
            if (ind % 1000000 == 0)
                Console.WriteLine(one / two);
        }
    }

    public void Timing()
    {
        var SWatch = new Stopwatch();
        SWatch.Start();
        int max = 100000000;
        int i = 0;
        int test = 0;
        for (i = 0; i < max; i++)
        {
            test += i;
        }
        SWatch.Stop();
        Console.WriteLine("Finito ciclo for " + max + " iterazioni");
        var time = SWatch.ElapsedMilliseconds;
        Console.WriteLine("Tempo totale: " + time);

        var SWatch1 = new Stopwatch();
        SWatch1.Start();
        i = 0;
        int[] Arr = new int[max];
        while(i < max - 1)
        {
            i++;
            Arr[i] = i;
        }
        SWatch1.Stop();
        Console.WriteLine("Finito ciclo while " + max + " iterazioni");
        var time1 = SWatch1.ElapsedMilliseconds;
        Console.WriteLine("Tempo totale: " + time1);
    }

    public ulong RecursiveFactorial(ulong n)
    {
        if (n == 0)
            return 1;
        return RecursiveFactorial(n - 1) * n;
    }

    public void SquareRoot()
    {
        int number = 2;
        decimal sqrt = 1.4142135623730950488016887m;
        decimal quad = sqrt * sqrt;
        Console.WriteLine("Radice di " + number + ": " + sqrt);
        Console.WriteLine("Quadrato di " + sqrt + ": " + quad);
        Console.WriteLine("Quadrato di " + sqrt + ": " + (Math.Pow((double)sqrt, 2)));
    }

    public string ToBinary(int number)
    {
        string bin = "";

        while (number > 1)
        {
            if (number % 2 == 0)
                bin += "0";
            else
                bin += "1";

            number = number/2;
        }
        bin += "1";
        char[] c = bin.ToCharArray();
        Array.Reverse(c);
        bin = new string(c);
        return bin;
    }

    public void BinarySum()
    {
        string n1 = ToBinary(734577356);
        string n2 = ToBinary(701456247);



        string n3 = n1;
        string n4 = n2;

        if (n3.Length > n4.Length)
            for (int i = n4.Length; i < n3.Length; i++)
                n4 = " " + n4;
        else
            for (int i = n3.Length; i < n4.Length; i++)
                n3 = " " + n3;

        n3 = " " + n3;
        n4 = " " + n4;
        Console.WriteLine(n3 + "+");
        Console.WriteLine(n4 + "=");

        if (n1.Length > n2.Length)
            for (int i = n2.Length; i < n1.Length; i++)
                n2 = "0" + n2;
        else
            for (int i = n1.Length; i < n2.Length; i++)
                n1 = "0" + n1;

        n1 = "0" + n1;
        n2 = "0" + n2;

        int index = 0;
        string result = "";
        int resto = 0;



        char[] c = n1.ToCharArray();
        Array.Reverse(c);
        n1 = new string(c);

        char[] c1 = n2.ToCharArray();
        Array.Reverse(c1);
        n2 = new string(c1);

        while (index < n2.Length)
        {
            int r1 = 0;
            int r2 = 0;

            if (n1.Substring(index, 1) == "1")
                r1 = 1;
            else if (n1.Substring(index, 1) == "0")
                r1 = 0;

            if (n2.Substring(index, 1) == "1")
                r2 = 1;
            else if (n2.Substring(index, 1) == "0")
                r2 = 0;

            int ris = 0;
            ris = r1 + r2 + resto;

            if (ris == 0)
            {
                resto = 0;
                result = "0" + result;
            } else if (ris == 1)
            {
                resto = 0;
                result = "1" + result;
            } else if (ris == 2)
            {
                resto = 1;
                result = "0" + result;
            } else if (ris == 3)
            {
                resto = 1;
                result = "1" + result;
            }
            index++;
        }

        if (result.Substring(0, 1) == "0")
        {
            result = result.Substring(1);
        }
        Console.WriteLine(result);
    }

    public void ComputePI()
    {
        int max = int.MaxValue;
        int i = 0;
        double cerchio = 1;
        double quadrato = 1;
        while (i < max)
        {
            double x = Ran.NextDouble();
            double y = Ran.NextDouble();
            double dist = Math.Sqrt(x * x + y * y);

            if (dist <= 1)
                cerchio++;
            quadrato++;

            if (i % 1000000 == 0)
            {
                Console.WriteLine((cerchio/quadrato)*4);
            }

            if ((cerchio/quadrato)*4 == 3.14159265358979323)
                Console.WriteLine((cerchio/quadrato)*4);
            i++;
        }

    }

    public void OneInAMillion()
    {
        int i = 1;
        int tmax = 0;
        int tmin = int.MaxValue;
        int media = 0;

        while (i < int.MaxValue)
        {
            var SWatch = new Stopwatch();
            SWatch.Start();
            bool found = false;
            while (!found)
            {
                if (Ran.Next(0, 1000000) == 7)
                    found = true;
            }
            SWatch.Stop();
            int time = (int)SWatch.ElapsedMilliseconds;
            Console.WriteLine("Trovato!");

            media += time;

            if (time  < tmin)
                tmin = time;
            else if (time > tmax)
                tmax = time;

            if (i % 10 == 0)
            {
                Console.WriteLine("Tempo massimo: " + tmax);
                Console.WriteLine("Tempo minimo: " + tmin);
                Console.WriteLine("Tempo medio: " + (media/i));
            }
            i++;
        }
    }

    public void BranchPrediction()
    {
        int i = 1;
        int max = int.MaxValue;
        int size = 1000000;
        while (i < max)
        {
            var SWatch = new Stopwatch();
            var SWatch1 = new Stopwatch();
            int idc = 0;
            int[] Arr = new int[size];
            for (int j = 0; j < size; j++)
                Arr[j] = Ran.Next(0, 100);

            SWatch.Start();
            for (int j = 0; j < size; j++)
                if (Arr[j] > (size / 2))
                    idc++;
                else
                    idc--;
            SWatch.Stop();

            Array.Sort(Arr);

            SWatch1.Start();
            for (int j = 0; j < size; j++)
                if (Arr[j] > (size / 2))
                    idc++;
                else
                    idc--;
            SWatch1.Stop();

            int time1 = (int)SWatch.ElapsedMilliseconds;
            int time2 = (int)SWatch1.ElapsedMilliseconds;

            Console.WriteLine("Array random: " + time1);
            Console.WriteLine("Array ordinato: " + time2);

            i++;
        }
    }

    public void RandomEqual()
    {
        int i = 0;
        int max = int.MaxValue;
        int zero = 1;
        int one = 1;
        int count = 0;
        while (i < max)
        {
            if (Ran.NextDouble() > 0.5)
                zero++;
            else
                one++;

            if (one == zero)
            {
                count++;
                Console.WriteLine("Number: " + one + " Count: " + count);
            }

            if (i % 10000000 == 0)
                Console.WriteLine("a");
            i++;
        }
    }
}
