using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Task1
    {

        public static void CircularArray(int n, int m)
        {

            int[,] arrCurc = new int[n, m];
            int count = 0;
            var sb = new StringBuilder();
            int sum = 0;
            for (int i = 0; i < arrCurc.GetLength(0); i++)
            {
                for (int j = 0; j < arrCurc.GetLength(1); j++)
                {
                    count++;
                    if (count > n)
                    {
                        count = 1;
                        arrCurc[i, j] = count;
                    }
                    else
                    {
                        arrCurc[i, j] = count;
                    }
                }
                count--;
                if (arrCurc[0, 0] == arrCurc[i, m - 1])
                {
                    break;
                }
            }
            for (int i = 0; i < arrCurc.GetLength(0); i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (arrCurc[i, 0] == 0)
                    {
                        break;
                    }
                    else
                    {
                        sb.Append(arrCurc[i, 0]);
                    }
                }
            }
            sum = int.Parse(sb.ToString());
            Console.WriteLine(sum);
        }
    }
}
