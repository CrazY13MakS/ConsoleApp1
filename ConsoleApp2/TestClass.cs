using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class TestClass
    {
        [Custom(0)]
        public int MyProperty { get; set; } = 15;

        [Custom(2)]

        public string Str { get; set; } = "1asdd";
        [Custom(3)]

        public decimal? Dec { get; set; }
        [Custom(1)]

        public int? INtNull { get; set; } = 122;
        [Custom(4)]

        public int? INtNull2 { get; set; } = 99809890;
    }
}
