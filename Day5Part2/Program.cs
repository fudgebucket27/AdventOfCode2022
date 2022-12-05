using Day5Part2;

var lines = File.ReadAllLines("input.txt");

var stacksLine = lines.Where(x => x.Contains("1")).First();
var stacksCount = int.Parse(stacksLine.Substring(stacksLine.Length - 2).Trim());

List<Stack> stacks = new List<Stack>();

for (int i = 1; i <= stacksCount; i++)
{
    Stack stack = new Stack();
    stack.StackId = i;
    stacks.Add(stack);
}

foreach (var line in lines)
{
    for (int i = 0; i < stacksCount; i++)
    {
        if (!string.IsNullOrEmpty(line) && !line.Contains("move"))
        {
            var crateData = line.Substring(i * 4, 3);
            if (crateData.Contains("["))
            {
                var crate = crateData[1];
                stacks[i].Crates.Add(crate.ToString());
            }
        }
    }
    if (line.Contains("move"))
    {
        var move = line.Split(" ");
        var toMove = stacks.First(x => x.StackId == Int32.Parse(move[3])).Crates.Take(Int32.Parse(move[1])).ToList();
        for(int i = (toMove.Count() - 1); i >= 0; i--)
        {
            stacks.First(x => x.StackId == Int32.Parse(move[5])).Crates.Insert(0, toMove[i]);
        }
        stacks.First(x => x.StackId == Int32.Parse(move[3])).Crates.RemoveRange(0, Int32.Parse(move[1]));
    }
}

var results = "";
foreach (var stack in stacks)
{
    results += stack.Crates[0];
}
Console.WriteLine($"Top crates {results}");
