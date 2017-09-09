using Rksoftware.PropertyCopy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSample
{
    class Program
    {
        static void Main(string[] args)
        {
            object result;
            Console.WriteLine(result =
                PropertyCopier.CopyTo(new Test1()
                {
                    MyProperty1 = 1,
                    MyProperty2 = "2",
                    MyProperty3 = 3,
                    MyProperty4 = 4,
                    MyProperty5 = 5,
                    MyProperty6 = "r",
                    MyProperty7 = "123",
                    MyProperty8 = new int[] { 123, 456, 789 },
                    MyProperty9 = new List<int>() { 123, 456, 789 },
                    MyProperty10 = new List<int>() { 123, 456, 789 },
                }, new Test2()));

            Console.ReadKey();
        }
    }

    class Test1
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public int? MyProperty3 { get; set; }
        public int MyProperty4 { get; set; }
        public int? MyProperty5 { get; set; }
        public string MyProperty6 { get; set; }
        public string MyProperty7 { get; set; }
        public int[] MyProperty8 { get; set; }
        public List<int> MyProperty9 { get; set; }
        public List<int> MyProperty10 { get; set; }
    }

    class Test2
    {
        public string MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public string MyProperty3 { get; set; }
        public int? MyProperty4 { get; set; }
        public int MyProperty5 { get; set; }
        public int MyProperty6 { get; set; }
        public int MyProperty7 { get; set; }
        public long[] MyProperty8 { get; set; }
        public List<long> MyProperty9 { get; set; }
        public IEnumerable<int> MyProperty10 { get; set; }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, new[] {
                $"{nameof(MyProperty1)}:{MyProperty1}",
                $"{nameof(MyProperty2)}:{MyProperty2}",
                $"{nameof(MyProperty3)}:{MyProperty3}",
                $"{nameof(MyProperty4)}:{MyProperty4}",
                $"{nameof(MyProperty5)}:{MyProperty5}",
                $"{nameof(MyProperty6)}:{MyProperty6}",
                $"{nameof(MyProperty7)}:{MyProperty7}",
                $"{nameof(MyProperty8)}:{MyProperty8}",
                $"{nameof(MyProperty9)}:{MyProperty9}",
                $"{nameof(MyProperty10)}:{MyProperty10}",
            });
        }
    }
}
