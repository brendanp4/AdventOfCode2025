class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\brend\Documents\input.txt";
        List<(long l, long r)> ranges = new();
        bool range = true;
        int total = 0;

        foreach (var line in File.ReadLines(path))
        {
            if(line == "")
            {
                range = false;
                continue;
            }
            if (range)
            {
                long l = long.Parse(line.Split('-')[0]);
                long r = long.Parse(line.Split('-')[1]);
                ranges.Add((l, r));
            }
            else
            {
                long ID = long.Parse(line);
                foreach (var r in ranges)
                {
                    if(ID >= r.l &&  ID <= r.r)
                    {
                        total++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(total);


        Console.WriteLine("Starting Part 2");

        //Part 2:
        List<(long l, long r)> SortedRanges = ranges.OrderBy(x => x.l).ToList();
        for (int i = 0; i < SortedRanges.Count; i++)
        {
            //Console.WriteLine($"Range: {SortedRanges[i].l} - {SortedRanges[i].r}");
            //Check that we're not at the end
            if (i <  SortedRanges.Count - 1)
            {
                //Console.WriteLine($"Comparing: {SortedRanges[i + 1].l} - {SortedRanges[i + 1].r}");
                //Check if the current range overlaps next range
                if (SortedRanges[i].r >= SortedRanges[i + 1].l)
                {
                    var item = SortedRanges[i];
                    item.r = Math.Max(SortedRanges[i].r, SortedRanges[i + 1].r);
                    SortedRanges[i] = item;
                    SortedRanges.RemoveAt(i + 1);

                    //Console.WriteLine($"New range: {SortedRanges[i].l} - {SortedRanges[i].r}");

                    i--;
                }
            }
        }

        long p2Total = 0;
        foreach(var r in SortedRanges)
        {
            p2Total += r.r - r.l;
            p2Total++;
        }

        Console.WriteLine($"{p2Total}");

    }
}

