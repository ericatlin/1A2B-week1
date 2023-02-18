using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _1.Product
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = GetProductList(@"C:\Users\erickimlin\Desktop\跨域黑客\02-17homework\product .csv");
            int pageSelect = 0;
            string select = "";
            while (true)
            {
                Console.WriteLine("歡迎來到B10810055-林智珉的第一周作業");
                Console.WriteLine("總頁數為4頁 請問您要看第幾頁 按5離開");
                select = Console.ReadLine();
                if ((select == null)||(select == ""))
                {
                    Console.Clear();
                    Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    pageSelect = int.Parse(select);
                }
                Console.WriteLine(pageSelect);
                if (pageSelect <= 5)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                    Console.ReadKey();
                    Console.Clear();

                    continue;
                }

            }
            while (true)
            {
                switch (pageSelect)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine($"1.商品的總價格為:{list.Sum(x => x.price)}");
                            Console.WriteLine();
                            Console.WriteLine($"2.商品的平均價格為:{list.Average(x => x.price)}");
                            Console.WriteLine();
                            Console.WriteLine($"3.商品的總數量為:{list.Sum(x => x.quantity)}");
                            Console.WriteLine();
                            Console.WriteLine($"4.商品的總數量為:{list.Average(x => x.quantity)}");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("總頁數為4頁 請問您要看第幾頁 按5離開");
                            select = Console.ReadLine();
                            if ((select == null) || (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                pageSelect = int.Parse(select);
                            }
                            
                            if (pageSelect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            var expitems = list.Where(x => x.price == list.Max(y => y.price));
                            foreach (var item in expitems)
                            {
                                Console.WriteLine($"5.最貴的商品是:{item.name}");
                            }
                            Console.WriteLine();
                            var lowitems = list.Where(x => x.price == list.Min(y => y.price));
                            foreach (var item in lowitems)
                            {
                                Console.WriteLine($"6.最便宜的商品是:{item.name}");
                            }
                            Console.WriteLine();
                            Console.WriteLine($"7.3C類別的總價為:{list.Where(x => x.category == "3C").Sum(x => x.price)}");
                            Console.WriteLine();
                            Console.WriteLine($"8.飲料和食品類別的總價為:{list.Where(x => x.category == "飲料" || x.category == "食品").Sum(x => x.price)}");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("總頁數為4頁 請問您要看第幾頁 按5離開");
                            select = Console.ReadLine();
                            if ((select == null) || (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                pageSelect = int.Parse(select);
                            }
                            
                            if (pageSelect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            var foodItem = list.Where(x => x.category == "食品" && x.quantity > 100);
                            Console.WriteLine($"9.食品類數量大於100的有:");
                            foreach (var item in foodItem)
                            {
                                Console.Write(item.name + ",");
                            }
                            Console.WriteLine();
                            Console.WriteLine();

                            Console.WriteLine($"10.食品類數量大於100的有:");
                            var typeItemGroupBy = list.Where(x => x.price > 1000).GroupBy(x => x.category);
                            foreach (var item in typeItemGroupBy)
                            {

                                foreach (var item1 in item)
                                {
                                    Console.WriteLine($"商品類別:{item1.category} 名稱:{item1.name}");
                                }
                            }

                            Console.WriteLine();
                            var typeItemGroupByAverage = list.Where(x => x.price > 1000).GroupBy(x => x.category);
                            int[] avgtotal = new int[typeItemGroupByAverage.Count()];
                            int i = 0, j = 0;
                            Console.WriteLine("11.上述類別平均");
                            foreach (var item in typeItemGroupByAverage)
                            {
                                foreach (var item1 in item)
                                {
                                    if (j == 0)
                                    {
                                        Console.Write(item1.category + "-------");
                                    }
                                    j++;
                                    int average = item1.price;
                                    avgtotal[i] = avgtotal[i] + average;
                                }
                                j = 0;
                                Console.WriteLine(avgtotal[i] / 3);
                                i++;
                            }
                            Console.WriteLine();
                            Console.WriteLine("12.依商品價格由高到低排序");
                            var PriceHiToLow = list.OrderByDescending(x => x.price);
                            foreach (var item in PriceHiToLow)
                            {
                                Console.WriteLine($"{item.id} {item.name} {item.quantity} {item.price} {item.category}");
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("總頁數為4頁 請問您要看第幾頁 按5離開");
                            select = Console.ReadLine();
                            if ((select == null) || (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                pageSelect = int.Parse(select);
                            }
                            if (pageSelect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                        }
                        break;
                    case 4:
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("13.依商品價格由低到高排序");
                            var PriceLowToHi = list.OrderBy(x => x.price);
                            foreach (var item in PriceLowToHi)
                            {
                                Console.WriteLine($"{item.id} {item.name} {item.quantity} {item.price} {item.category}");
                            }
                            Console.WriteLine();


                            Console.WriteLine("14.各類別最貴");
                            var typecheap = list.GroupBy(x => x.category);
                            int i1 = 0, j1 = 0;
                            string cheap = "";

                            foreach (var item in typecheap)
                            {
                                foreach (var item1 in item)
                                {
                                    if (i1 == 0)
                                    {
                                        Console.Write($"{item1.category}最貴的是:");
                                    }
                                    if (j1 < item1.price)
                                    {
                                        j1 = item1.price;
                                        cheap = item1.name;
                                    }
                                    i1++;
                                }
                                j1 = 0; i1 = 0;
                                Console.WriteLine(cheap);
                                cheap = "";

                            }
                            Console.WriteLine();



                            Console.WriteLine("15.各類別最便宜");
                            var typelow = list.GroupBy(x => x.category);
                            int i2 = 0, j2 = list.Max(x => x.price);
                            string low = "";

                            foreach (var item in typelow)
                            {
                                foreach (var item1 in item)
                                {
                                    if (i2 == 0)
                                    {
                                        Console.Write($"{item1.category}最便宜的是:");
                                    }
                                    if (j2 > item1.price)
                                    {
                                        j2 = item1.price;
                                        low = item1.name;
                                    }
                                    i2++;
                                }
                                j2 = list.Max(x => x.price);
                                i2 = 0;
                                Console.WriteLine(low);
                                low = "";

                            }
                            Console.WriteLine();
                            Console.WriteLine("16.價格小於等於10000的商品:");
                            var itemLowto10000 = list.Where(x => x.price <= 10000);
                            foreach (var item in itemLowto10000)
                            {
                                Console.WriteLine(item.name);
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("總頁數為4頁 請問您要看第幾頁 按5離開");
                            select = Console.ReadLine();
                            if ((select == null) || (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                pageSelect = int.Parse(select);
                            }
                            if (pageSelect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤，按隨意鍵重新選擇");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                        }
                        break; 
                    case 5:
                        {
                        break;
                        }

                }
                if (pageSelect == 5)
                {

                    break;
                }
            }
            Console.WriteLine("Bye Bye(任意鍵繼續");
            Console.ReadKey();
            
        }
        private static List<Product> GetProductList(string path) 
        { 
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length >0)
                .Select(Product.productRow).ToList();
        }
        
    }
    
}
