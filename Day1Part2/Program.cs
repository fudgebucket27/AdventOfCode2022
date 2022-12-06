using Day1Part2;

List<Elf> elves = new List<Elf>();
Elf elf = new Elf();
foreach (string line in System.IO.File.ReadLines("input.txt"))
{
    if (string.IsNullOrEmpty(line))
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

var elvesSorted = elves.OrderByDescending(x=>x.TotalCalories).ToList();
int highestCaloriesTop3 = elvesSorted[0].TotalCalories + elvesSorted[1].TotalCalories + elvesSorted[2].TotalCalories;
Console.WriteLine($"Top 3 elves hold {highestCaloriesTop3} calories");
