class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\brend\Documents\input.txt";
        List<List<int>> batteries = new();

        foreach (var line in File.ReadLines(path))
        {
            List<int> temp = new();
            foreach (var n in line)
            {
                temp.Add(n - 48);
            }
            batteries.Add(temp);
        }

        long sum = 0;
        foreach (var b in batteries)
        {
            long tempMax = 0;
            //int index = 0;
            //List<int> tempCur = new();
            //Dictionary<(int index, int left), List<int>> memo = new();
            //Helper(b, tempCur, ref index, ref tempMax, memo);

            //foreach (var m in memo)
            //{
            //    Console.WriteLine($"Index: {m.Key.index}");
            //    Console.WriteLine($"Left: {m.Key.left}");
            //    foreach(var n in m.Value)
            //    {
            //        Console.Write($"{n}, ");
            //    }
            //    Console.WriteLine("");
            //}

            tempMax = GetJoltage(b, 12);
            Console.WriteLine($"{tempMax}");
            sum += tempMax;
        }


        Console.WriteLine(sum.ToString());
    }

    //Sliding window attempt
    static long GetJoltage(List<int> bank, int batteries)
    {
        long joltage = 0;
        int left = 0;

        while (batteries > 0)
        {
            batteries--;
            int right = bank.Count - batteries;

            int currentMax = bank[left];
            int maxIndex = left;

            for (int i = left; i < right; i++)
            {
                if (bank[i] > currentMax)
                {
                    currentMax = bank[i];
                    maxIndex = i;
                }
            }

            joltage *= 10;
            joltage += currentMax;

            left = maxIndex + 1;
        }

        return joltage;
    }

    //Dynamic Programming attempt
    //static void Helper(List<int> battery, List<int> cur,ref int index, ref long max, Dictionary<(int dIndex, int dLeft), List<int>> memo)
    //{
    //    int left = 12 - cur.Count;

    //    if (memo.ContainsKey((index, left)))
    //    {
    //        cur.AddRange(memo.GetValueOrDefault((index, left)));
    //    }

    //    if (cur.Count == 12)
    //    {
    //        long currentValue = ListToNum(cur);
    //        if (currentValue > max) max = currentValue;
    //        return;
    //    }

    //    for (int i = 0; i < battery.Count; i++)
    //    {
    //        List<int> tempB = new(battery);
    //        List<int> tempC = new(cur);
    //        tempC.Add(tempB[i]);
    //        tempB.RemoveRange(0, i + 1);

    //        if (tempC.Count > 12) break;
    //        int bLeft = 12 - tempC.Count;

    //        //Logging:
    //        //Console.WriteLine("Battery:");
    //        //foreach (var n in tempB) Console.Write(n);
    //        //Console.WriteLine("");
    //        //Console.WriteLine("Voltage:");
    //        //foreach (var n in tempC) Console.Write(n);
    //        //Console.WriteLine("");


    //        Helper(tempB, tempC, ref i, ref max, memo);

    //        if (memo.ContainsKey((i, bLeft))) 
    //        {
    //            if(ListToNum(tempC.TakeLast(bLeft).ToList() ) > ListToNum(memo[(i, bLeft)] ) )
    //            {
    //                memo[(i, bLeft)] = tempC.TakeLast(bLeft).ToList();
    //            }
    //        }
    //        else memo.Add((i, bLeft), tempC.TakeLast(bLeft).ToList());

    //    }
    //}

    //static long ListToNum(List<int> nums)
    //{
    //    long num = 0;
    //    foreach (var n in nums)
    //    {
    //        num *= 10;
    //        num += n;
    //    }
    //    return num;
    //}


}

