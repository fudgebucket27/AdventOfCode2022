using Day7Part1;

string[] input = System.IO.File.ReadAllLines("input.txt");

List<Folder> directories = new List<Folder>();
string currentDirectory = "";
var currentCommand = "";
foreach(string line in input)
{
    var command = line.Split(' ');
    if (line[0] == '$')
    {
        if(command[1] == "cd" && command[2] != "..")
        {
            currentDirectory += command[2] + ",";

            if (!directories.Where(x=> x.Path == currentDirectory).Any())
            {
                Folder folder = new Folder();
                folder.Path = currentDirectory;
                directories.Add(folder);
            }
            currentCommand = "cd";
        }
        else if (command[1] == "cd" && command[2] == "..")
        {
            currentDirectory = String.Concat(currentDirectory.Split('/').Take(currentDirectory.Split('/').Length - 1).ToArray());
            currentCommand = "cd";
        }
        else if(command[1] == "ls")
        {
            currentCommand = "ls";
        }
    }
    if (currentCommand == "ls" && command[0] != "$")
    {
       
        if(command[0] != "dir") // dont care about dir unless we navigate inside
        {
            var fileSize = long.Parse(command[0]);
            var fileName = command[1];
            Day7Part1.File file = new Day7Part1.File();
            file.Name = fileName;
            file.Size= fileSize;
            if(directories.Where(x=> x.Path == currentDirectory && x.Files.Where(x=>x.Name==fileName).Any()).Any() == false)
            {
                directories.First(x => x.Path == currentDirectory).Files.Add(file);
            }
        }
    }
}
long totalDirectorySize = 0;
directories.OrderBy(x => x.Path);
foreach(var directory in directories)
{
    long currentDirectorySize = 0;
    foreach(var file in directory.Files)
    {
        currentDirectorySize += file.Size;
    }
    var subDirectories = directories.Where(x => x.Path.StartsWith(directory.Path + "/"));
    Console.WriteLine($"Directory {directory.Path}, Sub count: {subDirectories.Count()}");
    foreach(var subDirectory in subDirectories)
    {
        foreach (var file in subDirectory.Files)
        {
            currentDirectorySize += file.Size;
        }
    }

    if(currentDirectorySize <= 100000)
    {
        totalDirectorySize += currentDirectorySize;
    }
}
Console.WriteLine(totalDirectorySize);