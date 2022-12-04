List<string> pairAssignments = new List<string>();
using (StreamReader streamReader = new StreamReader("input.txt"))
{
    string item;
    while ((item = streamReader.ReadLine()!) != null)
    {
        pairAssignments.Add(item); // Add to list.     
    }
}

int totalPairMatch = 0;
foreach(string pairAssignment in pairAssignments)
{
    string[] pairs = pairAssignment.Split(',');
    int rangePairOne = Int32.Parse(pairs[0].Split('-')[1]) - Int32.Parse(pairs[0].Split('-')[0]) + 1;
    int rangePairTwo = Int32.Parse(pairs[1].Split('-')[1]) - Int32.Parse(pairs[1].Split('-')[0]) + 1;
    int pairMatch = 0;
    for (int i= Int32.Parse(pairs[0].Split('-')[0]); i <= Int32.Parse(pairs[0].Split('-')[1]); i++)
    {
        for (int j = Int32.Parse(pairs[1].Split('-')[0]); j <= Int32.Parse(pairs[1].Split('-')[1]); j++)
        {
            if(i == j)
            {
                pairMatch++;
            }
        }
    }

    if(pairMatch == rangePairTwo || pairMatch == rangePairOne)
    {
        totalPairMatch++;
    }
}

Console.WriteLine($"Total pair match: {totalPairMatch}");