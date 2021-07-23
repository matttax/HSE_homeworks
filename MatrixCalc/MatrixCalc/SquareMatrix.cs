using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixCalc
{
    class SquareMatrix : Matrix
    {
        public uint Order { get; private set; }
        public SquareMatrix(uint order, bool manualSet) : base(order, order, manualSet) {  Order = order; }
        public SquareMatrix (double[,] m) : base(m) { Order = Rows; }

        /// <summary>
        /// Turn into square matrix with zeros below the main diagonal by Gaussian elimination.
        /// </summary>
        /// <returns> Diagonal matrix and sign of the determinant. </returns>
        SquareMatrix ToTriangle(out double sign)
        {
            // Матрица приводится к треугольному виду элементарными преобразованиями.
            // С каждой перестановкой строк меняется знак определителя.
            sign = 1;
            double[,] triangleMatrix = (double[,])matrix.Clone();
            for (int i = 0; i < Order - 1; i++)
            {
                if (triangleMatrix[i, i] == 0)
                {
                    bool nonZero = false;
                    for (int j = i + 1; j < Order; j++)
                        if (triangleMatrix[j, i] != 0)
                        {
                            for (int k = 0; k < Order; k++)
                                (triangleMatrix[i, k], triangleMatrix[j, k]) = (triangleMatrix[j, k], triangleMatrix[i, k]);
                            sign = -1 * sign;
                            nonZero = true;
                            break;
                        }
                    if (!nonZero)
                        continue;
                }
                for (int j = i + 1; j < Order; j++)
                {
                    double constant = triangleMatrix[j, i] / triangleMatrix[i, i];
                    for (int k = i; k < Order; k++)
                        triangleMatrix[j, k] -= triangleMatrix[i, k] * constant;
                }
            }
            return new SquareMatrix(triangleMatrix);
        }

        /// <summary>
        /// Find sum or product of the elements on main diagonal.
        /// </summary>
        /// <returns> Sum or product of the elements on main diagonal. </returns>
        public double Trace(bool multiple)
        {
            double tr = multiple ? 1 : 0;
            for (int i = 0; i < Order; i++)
                tr = multiple ? tr * matrix[i, i] : tr + matrix[i,i];
            return tr;
        }

        /// <summary>
        /// Find determinant of the matrix.
        /// </summary>
        /// <returns> Determinant. </returns>
        public double Det() => ToTriangle(out double sign).Trace(true) * sign;
    }
}
