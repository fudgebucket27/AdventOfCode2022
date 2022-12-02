List<string> moves = new List<string>();
using (StreamReader streamReader = new StreamReader("input.txt"))
{
    string move;
    while ((move = streamReader.ReadLine()!) != null)
    {
        moves.Add(move); // Add to list.     
    }
}

int score = 0;

foreach (var move in moves)
{
    string opponentMove = move.Split(' ')[0];
    string myMove = move.Split(' ')[1];
    if (opponentMove == "A" && myMove == "X") //rock and lose. scissors
    {
        score += 3 + 0;
    }
    else if (opponentMove == "A" && myMove == "Y") //rock and draw. rock
    {
        score += 1 + 3;
    }
    else if (opponentMove == "A" && myMove == "Z") //rock and win. paper
    {
        score += 2 + 6;
    }
    else if (opponentMove == "B" && myMove == "X") //paper and  lose. rock
    {
        score += 1 + 0;
    }
    else if (opponentMove == "B" && myMove == "Y") //paper and draw. paper
    {
        score += 2 + 3;
    }
    else if (opponentMove == "B" && myMove == "Z") //paper and win. scissors. 
    {
        score += 3 + 6;
    }
    else if (opponentMove == "C" && myMove == "X") //scissors and lose. paper
    {
        score += 2 + 0;
    }
    else if (opponentMove == "C" && myMove == "Y") //scissors and draw. scissors
    {
        score += 3 + 3;
    }
    else if (opponentMove == "C" && myMove == "Z") //scissors and win. rock
    {
        score += 1 + 6;
    }
}

Console.WriteLine($"Total score {score}");
