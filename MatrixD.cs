using System;

public class MatrixD : Matrix<double>
{
    #region Public Constructors
    public MatrixD(int width, int height) : base(width, height) { }
    public MatrixD(Matrix<double> source) : base(source) { }
    public MatrixD(int width, int height, double[] data) : base(width, height, data) { }
    //Builds a matrix from a string in the form "0 1 12 | 15 2 7 | 10 6 8"
    public MatrixD(string source)
    {
        if (source is null)
        {
            throw new Exception("source may not be null.");
        }

        string[] columns = source.Split('|');
        string[][] dataStrings = new string[columns.Length][];

        for (int i = 0; i < columns.Length; i++)
        {
            dataStrings[i] = columns[i].Trim().Split(' ');
        }

        Height = dataStrings.Length;
        Width = dataStrings[0].Length;
        Data = new double[Width * Height];

        int index = 0;
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Data[index] = double.Parse(dataStrings[y][x]);
                index++;
            }
        }
    }
    #endregion
    public static void Forward(Matrix<double> matrix)
    {

    }
    public static void Backward(Matrix<double> matrix)
    {

    }
    //rowA -> rowB
    public void SwitchRows(int rowA, int rowB)
    {
        double[] rowBValues = GetRow(rowB);
        SetRow(rowB, GetRow(rowA));
        SetRow(rowA, rowBValues);
    }
    //scalar * rowA -> rowA
    public void ScaleRow(int row, double scalar)
    {
        double[] rowValues = GetRow(row);
        for (int i = 0; i < rowValues.Length; i++)
        {
            rowValues[i] *= scalar;
        }
        SetRow(row, rowValues);
    }
    //(constant * rowA) + rowB -> rowB.
    public void ReplaceRow(double constant, int rowA, int rowB)
    {
        double[] rowAValues = GetRow(rowA);
        for (int i = 0; i < rowAValues.Length; i++)
        {
            rowAValues[i] *= constant;
        }
        double[] rowBValues = GetRow(rowB);
        for (int i = 0; i < rowBValues.Length; i++)
        {
            rowBValues[i] += rowAValues[i];
        }
        SetRow(rowB, rowBValues);
    }
    //Displays a matrix to the console.
    public void Print()
    {
        for (int y = 0; y < Width; y++)
        {
            for (int x = 0; x < Height; x++)
            {
                if (x != 0)
                {
                    Console.Write(" ");
                }
                Console.Write(this[x, y]);
            }
            Console.WriteLine();
        }
    }
}