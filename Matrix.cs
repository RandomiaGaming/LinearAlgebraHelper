using System;
//Note array is filled first from left to right then from top to bottom.
public class Matrix<T>
{
    #region Public Variables
    public int Width { get; protected set; } = 0;
    public int Height { get; protected set; } = 0;
    public T[] Data { get; protected set; } = null;
    #endregion
    #region Protected Constructor
    protected Matrix() { }
    #endregion
    #region Public Constructors
    //Creates a matrix of type T with a given width and height. All values are default(T).
    public Matrix(int width, int height)
    {
        if (width <= 0)
        {
            throw new Exception("width must be greater than 0.");
        }
        if (height <= 0)
        {
            throw new Exception("height must be greater than 0.");
        }
        Width = width;
        Height = height;
        Data = new T[Width * Height];
    }
    //Creates a shallow copy of a matrix. T may not be copied properly for class types.
    public Matrix(Matrix<T> source)
    {
        if (source is null)
        {
            throw new Exception("source may not be null.");
        }
        Width = source.Width;
        Height = source.Height;
        Data = new T[Width * Height];
        Array.Copy(source.Data, 0, Data, 0, Width * Height);
    }
    //Creates a matrix from an array. The array is copied however T may not be copied properly for class types.
    public Matrix(int width, int height, T[] data)
    {
        if (width <= 0)
        {
            throw new Exception("width must be greater than 0.");
        }
        if (height <= 0)
        {
            throw new Exception("height must be greater than 0.");
        }
        if (data is null)
        {
            throw new Exception("data may not be null.");
        }
        if (data.Length != width * height)
        {
            throw new Exception("data.Length must equal width times height.");
        }
        Width = width;
        Height = height;
        Data = new T[Width * Height];
        Array.Copy(data, 0, Data, 0, Width * Height);
    }
    #endregion
    #region Public Accessor
    //Gets or sets a value within the matrix based upon x and y coordinants.
    public T this[int x, int y]
    {
        get
        {
            if (x < 0)
            {
                throw new Exception("x must be greater than or equal to 0.");
            }
            if (x >= Width)
            {
                throw new Exception("x must be less than Width.");
            }
            if (y < 0)
            {
                throw new Exception("y must be greater than or equal to 0.");
            }
            if (y >= Height)
            {
                throw new Exception("y must be less than Height.");
            }
            return Data[(Width * y) + x];
        }
        set
        {
            if (x < 0)
            {
                throw new Exception("x must be greater than or equal to 0.");
            }
            if (x >= Width)
            {
                throw new Exception("x must be less than Width.");
            }
            if (y < 0)
            {
                throw new Exception("y must be greater than or equal to 0.");
            }
            if (y >= Height)
            {
                throw new Exception("y must be less than Height.");
            }
            Data[(Width * y) + x] = value;
        }
    }
    #endregion
    #region Public Methods
    //Returns an entire row from the matrix as an array.
    public T[] GetRow(int y)
    {
        if (y < 0)
        {
            throw new Exception("y must be greater than or equal to 0.");
        }
        if (y >= Height)
        {
            throw new Exception("y must be less than Height.");
        }
        T[] output = new T[Width];
        Array.Copy(Data, Width * y, output, 0, Width);
        return output;
    }
    //Returns an entire column from the matrix as an array.
    public T[] GetColumn(int x)
    {
        if (x < 0)
        {
            throw new Exception("x must be greater than or equal to 0.");
        }
        if (x >= Width)
        {
            throw new Exception("x must be less than Width.");
        }
        T[] output = new T[Height];
        for (int y = 0; y < Height; y++)
        {
            output[y] = Data[x];
            x += Width;
        }
        return output;
    }
    //Sets an entire row of the matrix from an array.
    public void SetRow(int y, T[] data)
    {
        if (y < 0)
        {
            throw new Exception("y must be greater than or equal to 0.");
        }
        if (y >= Height)
        {
            throw new Exception("y must be less than Height.");
        }
        if (data is null)
        {
            throw new Exception("data may not be null.");
        }
        if (data.Length != Width)
        {
            throw new Exception("data.Length must equal Width.");
        }
        Array.Copy(data, 0, Data, Width * y, Width);
    }
    //Sets an entire column of the matrix from an array.
    public void SetColumn(int x, T[] data)
    {
        if (x < 0)
        {
            throw new Exception("x must be greater than or equal to 0.");
        }
        if (x >= Width)
        {
            throw new Exception("x must be less than Width.");
        }
        if (data is null)
        {
            throw new Exception("data may not be null.");
        }
        if (data.Length != Height)
        {
            throw new Exception("data.Length must equal Height.");
        }
        for (int y = 0; y < Height; y++)
        {
            Data[x] = data[y];
            x += Width;
        }
    }
    #endregion
}