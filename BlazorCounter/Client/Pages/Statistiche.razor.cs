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
}
