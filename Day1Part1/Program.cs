using Day1;

List<Elf> elves = new List<Elf>();
Elf elf = new Elf();
foreach (string line in System.IO.File.ReadLines("input.txt"))
{ 
    if(string.IsNullOrEmpty(line))
    {
        elf.TotalCalories = elf.Calories!.Sum();
        elves.Add(elf);
        elf = new Elf();
    }
    else
    {
     
        elf.Calories!.Add(Int32.Parse(line));
    }
}

var highestCalories = elves.Max(t=> t.TotalCalories);
Console.WriteLine($"Elf with highest calories has {highestCalories} calories");
