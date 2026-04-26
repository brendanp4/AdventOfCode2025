class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\brend\Documents\input.txt";
        List<char[]> papers = new();

        foreach (var line in File.ReadLines(path))
        {
            papers.Add(line.ToCharArray());
        }

        //int[,] neighbors = new int[papers.Count, papers[0].Length];
        //int neighbors = 0;
        int total = 0;
        bool found = true;

        while (found){
            found = false;
            for (int i = 0; i < papers.Count; i++)
            {
                for (int j = 0; j < papers[i].Length; j++)
                {
                    int neighbors = 0;

                    //Check above
                    if (i > 0)
                    {
                        //Check above left
                        if (j > 0 && (papers[i - 1][j - 1] == '@' || papers[i - 1][j - 1] == 'X')) neighbors++;
                        //Check directly above
                        if ((papers[i - 1][j] == '@' || papers[i - 1][j] == 'X')) neighbors++;
                        //Check above right
                        if (j < papers[i].Length - 1 && (papers[i - 1][j + 1] == '@' || papers[i - 1][j + 1] == 'X')) neighbors++;
                    }

                    //Check left and right
                    //Check left
                    if (j > 0 && (papers[i][j - 1] == '@' || papers[i][j - 1] == 'X')) neighbors++;
                    //Check right
                    if (j < papers[i].Length - 1 && (papers[i][j + 1] == '@' || papers[i][j + 1] == 'X')) neighbors++;

                    //Check below
                    if (i < papers.Count - 1)
                    {
                        //Check below left
                        if (j > 0 && (papers[i + 1][j - 1] == '@' || papers[i + 1][j - 1] == 'X')) neighbors++;
                        //Check directly below
                        if (papers[i + 1][j] == '@' || papers[i + 1][j] == 'X') neighbors++;
                        //Check below right
                        if (j < papers[i].Length - 1 && (papers[i + 1][j + 1] == '@' || papers[i + 1][j + 1] == 'X')) neighbors++;
                    }

                    if (neighbors < 4 && papers[i][j] == '@')
                    {
                        total++;
                        papers[i][j] = 'X';
                        found = true;
                    }

                }
            }
            CleanUp(papers);
        }

        Console.WriteLine(total);

    }

    static void CleanUp(List<char[]> table)
    {
        foreach(var p in table)
        {
            for(int i = 0; i < p.Length; i++)
            {
                if (p[i] == 'X') p[i] = '.';
            }
        }
    }

}

