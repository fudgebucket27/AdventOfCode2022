string input = File.ReadAllText("input.txt");
string marker = "";

int count = 0;
for (int i = 0; i < input.Length; i++)
{
    marker = new string(input.Skip(i).Take(14).ToArray());
    count++;
    if (marker.Distinct().Count() == 14)
    {
        count += 13;
        break;
    }
}

Console.WriteLine($"Result {count}");