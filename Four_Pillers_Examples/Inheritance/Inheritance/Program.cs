using System;
using static System.Console;
using System.Threading;

namespace Inheritance
{
    class Program
    {
        public class Vehicle
        {
            private readonly string _vehicleType;
            public Vehicle(string vehicleType)
            {
                _vehicleType = vehicleType;
            }

            public virtual void Start()
            {
                WriteLine("Started {0}", _vehicleType);
            }

            public virtual void Stop()
            {
                WriteLine("Stopped {0}", _vehicleType);
            }

            public virtual void Idle()
            {
                WriteLine("{0} is idling", _vehicleType);
            }
        }

        interface IGarage
        {
            void MaintainVehicle();
        }


        public class Car : Vehicle, IGarage
        {

            private readonly DateTime _lastMainenance;
            public Car(string vehicleType, DateTime lastMaintenace) : base(vehicleType)
            {
                _lastMainenance = lastMaintenace;
            }

            private bool MaintenanceRequired
            {
                get
                {
                    return _lastMainenance >= DateTime.Now.AddDays(90);
                }
            }

            public sealed override void Start()
            {
                base.Start();
                RunDiagnostics("Start");
            }

            public sealed override void Idle()
            {
                base.Idle();
                RunDiagnostics("Idle");
            }
            public sealed override void Stop()
            {
                base.Stop();
                RunDiagnostics("Stop");
            }

            private void RunDiagnostics(string type)
            {
                WriteLine("Running {0} diagnostics on car", type);
                for (var i = 1; i <= 3; i++)
                {
                    WriteLine("Test {0}", i);
                    Thread.Sleep(1000);
                }
            }

            public void MaintainVehicle()
            {
                WriteLine("Do we need maintenance on car {0}", MaintenanceRequired);
                if (MaintenanceRequired)
                {
                    WriteLine("Rotating Tires On Car");
                    Thread.Sleep(3000);
                }
            }

            public void TestBrakes()
            {
                WriteLine("Testing car's brakes");
                Thread.Sleep(3000);
            }
        }
        public sealed class Plane : Vehicle, IGarage
        {
            private readonly DateTime _lastMainenance;

            public Plane(string vehicleType, DateTime lastMaintenace) : base(vehicleType)
            {
                _lastMainenance = lastMaintenace;
            }

            private bool MaintenanceRequired
            {
                get
                {
                    return _lastMainenance >= DateTime.Now.AddDays(90);
                }
            }

            public sealed override void Start()
            {
                base.Start();
                RunDiagnostics("Start");
            }

            public sealed override void Idle()
            {
                base.Idle();
                RunDiagnostics("Idle");
            }
            public sealed override void Stop()
            {
                base.Stop();
                RunDiagnostics("Stop");
            }

            private void RunDiagnostics(string type)
            {
                WriteLine("Running {0} diagnostics on plane", type);
                for (var i = 1; i <= 3; i++)
                {
                    WriteLine("Test {0}", i);
                    Thread.Sleep(1000);
                }
            }

            public void MaintainVehicle()
            {
                WriteLine("Do we need maintenance on plane {0}", MaintenanceRequired);
                if (MaintenanceRequired)
                {
                    WriteLine("Changing propeller On Plane");
                    Thread.Sleep(3000);
                }
            }
            public void TestBrakes()
            {
                WriteLine("Testing Plane's brakes");
                Thread.Sleep(3000);
            }
        }

        public sealed class Boat : Vehicle, IGarage
        {

            private readonly DateTime _lastMainenance;
            public Boat(string vehicleType, DateTime lastMaintenace) : base(vehicleType)
            {
                _lastMainenance = lastMaintenace;
            }

            private bool MaintenanceRequired
            {
                get
                {
                    return _lastMainenance >= DateTime.Now.AddDays(90);
                }
            }

            public sealed override void Start()
            {
                base.Start();
                RunDiagnostics("Start");
            }

            public sealed override void Idle()
            {
                base.Idle();
                RunDiagnostics("Idle");
            }
            public sealed override void Stop()
            {
                base.Stop();
                RunDiagnostics("Stop");
            }

            private void RunDiagnostics(string type)
            {
                WriteLine("Running {0} diagnostics on boat", type);
                for (var i = 1; i <= 3; i++)
                {
                    WriteLine("Test {0}", i);
                    Thread.Sleep(1000);
                }
            }

            public void MaintainVehicle()
            {
                WriteLine("Do we need maintenance on Boat {0}", MaintenanceRequired);
                if (MaintenanceRequired)
                {
                    WriteLine("Changing propeller On Boat");
                    Thread.Sleep(3000);
                }
            }

            public void TestHydroDisplacement()
            {
                WriteLine("Testing boat's hydro diplacment");
                Thread.Sleep(3000);
            }
        }
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[3];
            vehicles[0] = new Car("Car", DateTime.Now.AddDays(95));
            vehicles[1] = new Plane("Plane", DateTime.Now.AddDays(40));
            vehicles[2] = new Boat("Boat", DateTime.Now.AddDays(100));

            foreach (var v in vehicles)
            {
                v.Start();
                v.Idle();
                v.Stop();
            }

            foreach (IGarage v in vehicles)
            {
                MaintainVehicle(v);

                if (v is Car)
                {
                    Car car = v as Car;
                    car.TestBrakes();
                }
                if (v is Plane)
                {
                    Plane plane = v as Plane;
                    plane.TestBrakes();
                }

                if (v is Boat)
                {
                    Boat boat = v as Boat;
                    boat.TestHydroDisplacement();
                }
            }

            WriteLine("Complete........................");
            ReadKey();
        }
        static void MaintainVehicle(IGarage v)
        {
            v.MaintainVehicle();
        }
    }
}
