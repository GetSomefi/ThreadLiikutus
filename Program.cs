namespace ThreadLiikutus;
class Program
{
    public static int count = 0;  
    static void Main(string[] args)
    {
        string line = "----------";
        int lines = 4;
        //char charToMove = '|';

        BackAndForth movement = new BackAndForth(line,lines);
        Thread t1 = new Thread(new ThreadStart(movement.DrawLine));
        t1.Start();

        Thread t2 = new Thread(new ThreadStart(movement.GetKeyStrokes));
        t2.Start();
    }
}
