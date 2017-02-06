using System;
using System.Collections.Generic;
using static System.Console;

namespace InterfacePolymorphicBavior
{
    class Program
    {
        interface IVehicle
        {
            void Start();

            void Stop();

            void Idle();
        }

        public class Car : IVehicle
        {
            public void Idle()
            {
                WriteLine("The car is Idling");
            }

            public void Start()
            {
               Console.WriteLine("The car has Started");
            }

            public void Stop()
            {
               WriteLine("The car has stopped");
            }
        }

        public class Boat : IVehicle
        {
            public void Idle()
            {
                WriteLine("The Boat is Idling");
            }

            public void Start()
            {
                WriteLine("The Boat has Started");
            }
            public void Stop()
            {
                WriteLine("The Boat has stopped");
            }
        }

        public class Plane : IVehicle
        {
            public void Idle()
            {
                WriteLine("The Plane is Idling");
            }

            public void Start()
            {
                WriteLine("The Plane has Stared");
            }
            public void Stop()
            {
                WriteLine("The Plane has stopped");
            }
        }

        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();
            vehicles.Add(new Car());
            vehicles.Add(new Boat());
            vehicles.Add(new Plane());

            foreach (var v in vehicles)
            {
                ActivateVehicle(v);
            }
            Console.ReadKey();
        }

        static void ActivateVehicle(IVehicle v)
        {
            v.Start();
            v.Idle();
            v.Stop();
        }
    }
}
