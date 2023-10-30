using System;

public class MathOperations
{
    public static T Add<T>(T a, T b)
    {
        dynamic x = a;
        dynamic y = b;
        return x + y;
    }

    public static T[] Add<T>(T[] arr1, T[] arr2)
    {
        if (arr1.Length != arr2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        T[] result = new T[arr1.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = Add(arr1[i], arr2[i]);
        }
        return result;
    }

    public static T[,] Add<T>(T[,] matrix1, T[,] matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must have the same dimensions.");

        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        T[,] result = new T[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = Add(matrix1[i, j], matrix2[i, j]);
            }
        }
        return result;
    }

}

class Program
{
    static void Main()
    {
        int num1 = 5;
        int num2 = 7;
        Console.WriteLine(MathOperations.Add(num1, num2)); 

        double[] arr1 = { 1.1, 2.2, 3.3 };
        double[] arr2 = { 4.4, 5.5, 6.6 };
        double[] resultArray = MathOperations.Add(arr1, arr2); 
        Console.WriteLine(string.Join(", ", resultArray));

        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
        int[,] resultMatrix = MathOperations.Add(matrix1, matrix2); 
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                Console.Write(resultMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
