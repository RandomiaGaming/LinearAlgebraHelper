using System;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        MatrixD matrix = new MatrixD("0 1 2 | 3 4 5 | 6 7 8");
        matrix.Print();
        Console.ReadLine();
    }
}
