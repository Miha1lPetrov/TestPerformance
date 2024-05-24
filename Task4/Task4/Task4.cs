using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    internal class Task4
    {
        public static void OneToOne(string path)
        {
            char[] delimetr = { ' ', '\n', '\t', '\r' };
            string[] arrStr = File.ReadAllText(path).ToString().Split(delimetr, StringSplitOptions.RemoveEmptyEntries);

            int[] arrNum = new int[arrStr.Length];
            double averageNum = 0;
            int countSteps = 0;

            for (int i = 0; i < arrStr.Length; i++)
            {
                arrNum[i] = int.Parse(arrStr[i]);
                averageNum += arrNum[i];
            }
            averageNum = averageNum / arrNum.Length;

            Array.Sort(arrNum);
            for (int i = 0; i < arrNum.Length; i++)
            {
                if (arrNum[i] >= averageNum)
                {
                    averageNum = arrNum[i];
                    break;
                }
            }
            while (true)
            {
                bool flag = false;
                for (int i = 0; i < arrNum.Length; i++)
                {
                    if (arrNum[i] < averageNum)
                    {
                        flag = true;
                        arrNum[i]++;
                        countSteps++;
                    }
                    else if (arrNum[i] > averageNum)
                    {
                        flag = true;
                        arrNum[i]--;
                        countSteps++;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }
            Console.WriteLine(countSteps);
        }
    }
}
