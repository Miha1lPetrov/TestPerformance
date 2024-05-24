using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    internal class Task2
    {
        public static void PositionPointCircle(string pathCoordinatesCircle, string pathCoordinatesPoint)
        {

            char[] delimetr = { ' ', '\t', '\n', '\r' };
            string[] circleArr = File.ReadAllText($"{pathCoordinatesCircle}").ToString().Split(delimetr, StringSplitOptions.RemoveEmptyEntries);
            string[] pointArr = File.ReadAllText($"{pathCoordinatesPoint}").ToString().Split(delimetr, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            int[,] circleArrNum = new int[circleArr.Length / 3, 3];
            int[,] pointArrNum = new int[pointArr.Length / 2, 2];

            for (int i = 0; i < circleArrNum.GetLength(0); i++)
            {
                for (int j = 0; j < circleArrNum.GetLength(1); j++)
                {
                    circleArrNum[i, j] = int.Parse(circleArr[count]);
                    count++;
                }
            }
            count = 0;
            for (int i = 0; i < pointArrNum.GetLength(0); i++)
            {
                for (int j = 0; j < pointArrNum.GetLength(1); j++)
                {
                    pointArrNum[i, j] = int.Parse(pointArr[count]);
                    count++;
                }
            }

            for (int i = 0; i < circleArrNum.Length / 3; i++)
            {
                int circleX = circleArrNum[i, 0];
                int circleY = circleArrNum[i, 1];
                int circleR = circleArrNum[i, 2];
                for (int j = 0; j < pointArrNum.Length / 2; j++)
                {
                    int pointX = pointArrNum[j, 0];
                    int pointY = pointArrNum[j, 1];
                    double distance = Math.Sqrt(Math.Pow(circleX - pointX, 2) + Math.Pow(circleY - pointY, 2));
                    if (distance < circleR)
                    {
                        Console.WriteLine(1);
                    }
                    else if (distance == circleR)
                    {
                        Console.WriteLine(0);
                    }
                    else
                    {
                        Console.WriteLine(2);
                    }
                }
            }

        }



    }
}
