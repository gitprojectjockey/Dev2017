using System;

namespace ExtentingMyClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var widget = new Widget() { Id = 1, Name = "Blue Widget", Created = DateTime.Now.AddHours(-3), LotCode = "L2351" };
            var locationDockCode = widget.GetLoadingDockLocationCode(widget);

            Console.WriteLine("Hello World!");
        }
    }
}
