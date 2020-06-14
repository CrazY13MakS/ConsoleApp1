using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp2
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class CustomAttribute : Attribute
    {
        public CustomAttribute(uint value)
        {
            Index = value;
        }   
        // This is a named argument
        public uint Index { get; }
    }
}
