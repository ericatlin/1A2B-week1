using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1A2B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arryRndnum = new string[4];
            
            //宣告變數

            Random rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                arryRndnum[i] = Convert.ToString(rnd.Next(0, 9));

                if (arryRndnum[0] == "0")
                {
                    arryRndnum[0] = Convert.ToString(rnd.Next(1, 9));
                }
                //第一位數字不為零

                for (int j = 0; j < i; j++)
                {
                    if (arryRndnum[j] == arryRndnum[i])
                    {
                        j = 0;
                        arryRndnum[i] = Convert.ToString(rnd.Next(0, 9));
                    }
                }
                Console.WriteLine(arryRndnum[i]);
            }
            //亂數
            
            Console.WriteLine("請輸入4個不重複的數字");
            string plyNum = Console.ReadLine();
            string[] arrPlyNum = new string[4];
            for (int i = 0; i < 4; i++)
            {
                arrPlyNum[i] = Convert.ToString(plyNum[i]);
            }
            var intersect = arrPlyNum.Intersect(arryRndnum);
            Console.WriteLine("聯集的結果為");
            string[] a = new string[4];
            int k = 0;
            foreach (var item in intersect)
            {
                var person2 = arryRndnum.First((x) => x == item);
                Console.WriteLine($"小於30歲的人第一個被找到的是:{person2}");
            }
            

            Console.ReadLine();
        }
        
    }
}
