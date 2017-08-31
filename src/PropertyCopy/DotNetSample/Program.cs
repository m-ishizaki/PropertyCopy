﻿using Rksoftware.PropertyCopy;
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
            Console.WriteLine(PropertyCopier.CopyTo(new Test1()
            {
                MyProperty1 = 1,
                MyProperty2 = "2",
                MyProperty3 = 3,
                MyProperty4 = 4,
                MyProperty5 = 5,
                MyProperty6 = "r"
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

        public override string ToString()
        {
            return string.Join(Environment.NewLine, new[] { $"{nameof(MyProperty1)}:{MyProperty1}", $"{nameof(MyProperty2)}:{MyProperty2}", $"{nameof(MyProperty3)}:{MyProperty3}", $"{nameof(MyProperty4)}:{MyProperty4}", $"{nameof(MyProperty5)}:{MyProperty5}", $"{nameof(MyProperty6)}:{MyProperty6}", $"{nameof(MyProperty7)}:{MyProperty7}" });
        }
    }

}