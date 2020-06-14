using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new TestClass();
            Console.WriteLine(GetValues(data));
            Console.WriteLine("Hello World!");
        }

        static string GetValues(object data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }


            Delegate.CreateDelegate(typeof(Func<PropertyInfo, object, string>),)



            var type = data.GetType();
            var fileds = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty).Where(x => !x.GetGetMethod().IsVirtual && x.IsDefined(typeof(CustomAttribute))).ToDictionary(
                x => x,
                y =>
                {
                    var attr = y.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(CustomAttribute));
                    var a = y.GetCustomAttribute(typeof(CustomAttribute)) as CustomAttribute;
                    return a.Index;
                }).OrderBy(x=>x.Value).ToDictionary(x=>x.Key, y=>y.Value);
            if(fileds.Values.GroupBy(x=>x).Any(x=>x.Count()>1))
            {
                throw new ArgumentException($"CustomAttribute order value in type {type.FullName} has duplicates");
            }

            if (fileds.Values.SkipWhile((el, index)=>el==index).Any())
            {
                throw new ArgumentException($"The item numbers in the object type {type.FullName} are not shown in order; there are gaps");
            }
            var elements = fileds.OrderBy(x => x.Value).Select(x => x.Key.GetValue(data)?.ToString());
            return string.Join('|', elements);            

        }

        static Func<object,PropertyInfo[]> GetFunc(object data)
        {
            var type = data.GetType();
            var fileds = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty).Where(x => !x.GetGetMethod().IsVirtual && x.IsDefined(typeof(CustomAttribute))).ToDictionary(
               x => x,
               y =>
               {
                   var attr = y.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(CustomAttribute));
                   var a = y.GetCustomAttribute(typeof(CustomAttribute)) as CustomAttribute;
                   return a.Index;
               }).OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            if (fileds.Values.GroupBy(x => x).Any(x => x.Count() > 1))
            {
                throw new ArgumentException($"CustomAttribute order value in type {type.FullName} has duplicates");
            }

            if (fileds.Values.SkipWhile((el, index) => el == index).Any())
            {
                throw new ArgumentException($"The item numbers in the object type {type.FullName} are not shown in order; there are gaps");
            }
        }

        static Func<Type, IEnumerable<KeyValuePair<PropertyInfo, uint>>> GetFunc2(Type type)
        {
            System.Linq.Expressions.Expression<Func<Type, IEnumerable<KeyValuePair<PropertyInfo, uint>>>> expr = type => type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty).Where(x => !x.GetGetMethod().IsVirtual && x.IsDefined(typeof(CustomAttribute))).ToDictionary(
               x => x,
               y => ((CustomAttribute)y.GetCustomAttribute(typeof(CustomAttribute))).Index
               );
            return expr.Compile();
        }

        static Func<Type, IEnumerable<KeyValuePair<PropertyInfo, uint>>> GetFunc2(Type type)
        {
            System.Linq.Expressions.Expression<Func<Type, IEnumerable<KeyValuePair<PropertyInfo, uint>>>> expr = type => type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty).Where(x => !x.GetGetMethod().IsVirtual && x.IsDefined(typeof(CustomAttribute))).ToDictionary(
               x => x,
               y => ((CustomAttribute)y.GetCustomAttribute(typeof(CustomAttribute))).Index
               );
            return expr.Compile();
        }
    }
}
