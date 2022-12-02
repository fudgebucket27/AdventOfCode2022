List<string> moves = new List<string>();
using (StreamReader streamReader = new StreamReader("input.txt"))
{
    string move;
    while ((move = streamReader.ReadLine()!) != null)
    {
        moves.Add(move); // Add to list.     
    }
}
