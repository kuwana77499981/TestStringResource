using System.Globalization;
using TestStringResourceStandard;

namespace TestStringResourceStandardApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Func<CultureInfo?, string?> testFunc = TestClass.GetHelloWorldString;

            Console.WriteLine(testFunc(null));

            Console.WriteLine(testFunc(new CultureInfo("en-US")));

            Console.WriteLine(testFunc(new CultureInfo("fr-FR")));

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Console.WriteLine(testFunc(null));


            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            Console.WriteLine(testFunc(null));
        }
    }
}