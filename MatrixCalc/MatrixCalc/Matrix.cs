using System;
using System.Linq;

namespace MatrixCalc
{
    class Matrix
    {
        public uint Rows { get; private set; }
        public uint Columns { get; private set; }
        public double[,] matrix { get; protected set; }

        /// <summary> Set matrix. </summary>
        public Matrix(uint rows, uint columns, bool manualSet)
        {
            Rows = rows;
            Columns = columns;
            matrix = new double[rows, columns];
            if (manualSet)
                for (int i = 0; i < rows; i++)
                {
                    int[] row = new int[0];
                    try
                    {
                        Console.WriteLine($"Write {i+1} row (split elements with space):");
                        row = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(x => int.Parse(x)).ToArray();
                        if (row.Length > columns)
                            throw new ArgumentOutOfRangeException();
                        for (int j = 0; j < columns; j++)
                            matrix[i, j] = j < row.Length ? row[j] : 0;
                    }
                    catch { Console.WriteLine("Incorrect input."); i--; } 
                }
        }

        /// <summary> Create matrix out of 2-dimentional array of doubles. </summary>
        public Matrix(double[,] m)
        {
            Rows = (uint) m.GetLength(0);
            Columns = (uint) m.GetLength(1);
            matrix = m;
        }
        public double this[uint row, uint column] => matrix[row,column];

        /// <summary> Transpose matrix (swap rows with columns). </summary>
        /// <returns> Transposed matrix. </returns>
        public Matrix Transpose()
        {
            double[,] transposedMatrix = new double[Columns, Rows];
            for (int i = 0; i < transposedMatrix.GetLength(0); i++)
                for (int j = 0; j < transposedMatrix.GetLength(1); j++)
                    transposedMatrix[i, j] = matrix[j, i];
            return new Matrix(transposedMatrix);
        }

        /// <summary> Overloaded operators for most common operations with matrices. </summary>
        #region Operators
        public static Matrix operator *(double c, Matrix matrix)
        {
            Matrix newMatrix = new Matrix(matrix.Rows, matrix.Columns, false);
            for (uint i = 0; i < matrix.Rows; i++)
                for (uint j = 0; j < matrix.Columns; j++)
                    newMatrix.matrix[i, j] = matrix[i, j] * c;
            return newMatrix;
        }
        public static Matrix operator *(Matrix matrix, double c) => c * matrix;
        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
                throw new ArrayTypeMismatchException();
            Matrix newMatrix = new Matrix(matrixA.Rows, matrixA.Columns, false);
            for (uint i = 0; i < matrixA.Rows; i++)
                for (uint j = 0; j < matrixA.Columns; j++)
                    newMatrix.matrix[i, j] = matrixA[i, j] + matrixB[i, j];
            return newMatrix;
        }
        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.Columns != matrixB.Rows)
                throw new ArrayTypeMismatchException();
            Matrix newMatrix = new Matrix(matrixA.Rows, matrixB.Columns, false);
            for (uint i = 0; i < matrixA.Rows; i++)
                for (uint j = 0; j < matrixB.Columns; j++)
                {
                    double element = 0;
                    for (uint k = 0; k < matrixB.Rows; k++)
                        element += matrixA[i, k] * matrixB[k, j];
                    newMatrix.matrix[i, j] = element;
                }
            return newMatrix;
        }
        public static Matrix operator /(SquareMatrix matrixA, Matrix vectorB)
        {
            if (vectorB.Rows != matrixA.Order || vectorB.Columns != 1)
                throw new ArrayTypeMismatchException();
            if (matrixA.Det() == 0)
                throw new InvalidOperationException();
            double[,] vectorX = new double[matrixA.Order, 1];
            for (int i = 0; i < matrixA.Order; i++)
            {
                double[,] BinA = (double[,])matrixA.matrix.Clone();
                for (uint m = 0; m < matrixA.Order; m++)
                    for (uint n = 0; n < matrixA.Order; n++)
                        if (m == i)
                            BinA[n, m] = vectorB[n, 0];
                vectorX[i, 0] = new SquareMatrix(BinA).Det()/matrixA.Det();
            }
            return new Matrix(vectorX);
        }
        #endregion

        /// <summary> For printing matrix. </summary>
        /// <returns> Matrix in string format. </returns>
        public override string ToString()
        {
            string m = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    m += string.Format("{0:0.00}", matrix[i, j]) + "\t";
                m += "\n";
            }
            return m;
        }
    }
}
