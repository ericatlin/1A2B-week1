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

            while (true)
            {
                Random rnd = new Random();
                int a = 0, b = 0;
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
                Console.WriteLine("歡迎來到1A2B猜數字遊戲~");

                for (int z = 1; z != 0; z++)
                {
                    Console.WriteLine("請輸入4個不重複的數字");
                    string plyNum = Console.ReadLine();
                    string[] arrPlyNum = new string[4];
                    for (int i = 0; i < 4; i++)
                    {
                        arrPlyNum[i] = Convert.ToString(plyNum[i]);
                    }
                    var intersect = arrPlyNum.Intersect(arryRndnum);


                    foreach (var item in intersect)
                    {

                        if (Array.IndexOf(arryRndnum, item) == Array.IndexOf(arrPlyNum, item))
                        {
                            a++;
                        }
                        else
                        {
                            b++;
                        }
                    }
                    Console.WriteLine($"判定結果是 {a}A{b}B");
                    if (a == 4)
                    {
                        Console.WriteLine("恭喜你!猜對了!!!");
                        break;
                    }
                    a = 0; b = 0;
                }
                Console.WriteLine("是否要繼續遊玩?(y/n):");
                string yn = Console.ReadLine();
                if (yn == "n")
                {
                    break;
                }
                Console.ReadKey();
            }
        }
        
    }
}
