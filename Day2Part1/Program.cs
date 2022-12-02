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

foreach(var move in moves)
{
    string opponentMove = move.Split(' ')[0];
    string myMove = move.Split(' ')[1];
    if(opponentMove == "A" && myMove == "X") //rock and rock. draw
    {
        score += 1 + 3;
    }
    else if (opponentMove == "A" && myMove == "Y") //rock and paper. win
    {
        score += 2 + 6;
    }
    else if (opponentMove == "A" && myMove == "Z") //rock and scissors. lose
    {
        score += 3 + 0;
    }
    else if (opponentMove == "B" && myMove == "X") //paper and rock. lose
    {
        score += 1 + 0;
    }
    else if (opponentMove == "B" && myMove == "Y") //paper and paper. draw
    {
        score += 2 + 3;
    }
    else if (opponentMove == "B" && myMove == "Z") //paper and scissors. win
    {
        score += 3 + 6;
    }
    else if (opponentMove == "C" && myMove == "X") //scissors and rock. win
    {
        score += 1 + 6;
    }
    else if (opponentMove == "C" && myMove == "Y") //scissors and paper. lose
    {
        score += 2 + 0;
    }
    else if (opponentMove == "C" && myMove == "Z") //scissors and scissors. draw
    {
        score += 3 + 3;
    }
}

Console.WriteLine($"Total score {score}");
