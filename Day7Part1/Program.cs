using Day7Part1;

string[] input = System.IO.File.ReadAllLines("input.txt");

List<Folder> directory = new List<Folder>();
string currentDirectory = "";
var currentCommand = "";
foreach(string line in input)
{
    var command = line.Split(' ');
    if (line[0] == '$')
    {
        if(command[1] == "cd" && command[2] != "..")
        {
            currentDirectory += "/" + command[2] ;
            if(!directory.Where(x=> x.Path == currentDirectory).Any())
            {
                Folder folder = new Folder();
                folder.Path = currentDirectory;
                directory.Add(folder);
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
            if(directory.Where(x=> x.Path == currentDirectory && x.Files.Where(x=>x.Name==fileName).Any()).Any() == false)
            {
                directory.First(x => x.Path == currentDirectory).Files.Add(file);
            }
        }
    }
}
var totalSize = directory.Sum(x=> x.Files.Sum(x=> x.Size));
Console.WriteLine(totalSize);