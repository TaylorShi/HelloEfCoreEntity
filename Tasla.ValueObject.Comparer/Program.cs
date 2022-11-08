using System;
using System.Collections.Generic;
using Tesla.Practing.Domain.AggregatesModel.OrderAggregates;

namespace Tasla.ValueObject.Comparer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var one = new Address("沙头街道", "深圳", "广东省","中国", "518000");
            var two = new Address("沙头街道", "深圳", "广东省", "中国", "518000");

            Console.WriteLine(EqualityComparer<Address>.Default.Equals(one, two)); // True
            Console.WriteLine(object.Equals(one, two)); // True
            Console.WriteLine(one.Equals(two)); // True
            Console.WriteLine(one == two); // True
            Console.ReadKey();
        }
    }
}
