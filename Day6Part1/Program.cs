string input = File.ReadAllText("input.txt");
string marker = "";

int count = 0;
for(int i=0; i < input.Length; i++)
{
    marker = new string(input.Skip(i).Take(4).ToArray());
    count++;
    if(marker.Distinct().Count() == 4)
    {
        count += 3;
        break;
    }
}

Console.WriteLine($"Result {count}");