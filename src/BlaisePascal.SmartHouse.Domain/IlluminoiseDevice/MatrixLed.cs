using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.IlluminoiseDevice
{
    public sealed class MatrixLed : Device
    {
        public Led[,] matrix { get; }
        public MatrixLed(int rows, int cols, Led led)
        {
            matrix = new Led[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = led;
                }
            }
        }

        public void SwitchOnAll()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j].TurnOn();
                }
            }
        }

        public void SwitchOffAll()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j].TurnOff();
                }
            }
        }

        public void SetIntensityAll(int intensity)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j].LightIntensityPropriety = intensity;
                }
            }
        }

        public void patternCheckerboard()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        matrix[i, j].TurnOn();
                    }
                    else
                    {
                        matrix[i, j].TurnOff();
                    }
                }
            }
        }

        public Led GetLed(int row, int column)
        {
            return matrix[row, column];
        }

        public List<Led> GetLedsInRow(int row)
        {
            List<Led> lampsInRow = new List<Led>();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                lampsInRow.Add(matrix[row, j]);
            }
            return lampsInRow;
        }

        public List<Led> GetLedsInColumn(int column)
        {
            List<Led> lampsInColumn = new List<Led>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                lampsInColumn.Add(matrix[i, column]);
            }
            return lampsInColumn;
        }

    }
}
