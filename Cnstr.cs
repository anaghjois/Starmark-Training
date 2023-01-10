using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class car
    {
        public string ChassiNo { get; set; }
        public string BodyType { get; set; }
        public string FuleType { get; set; }
        public int  NoOfSeats { get; set; }
        public Infotainment Infotainment { get; set; } = new Infotainment { Name = "sony", HasMaps = false };
        
        public void Run()
        {
            Console.WriteLine("Car has started");
            Console.WriteLine("Player of the type {0} has started in {1}", Infotainment.CurrentPlayer, Infotainment.Name);
        }
    }
    class Infotainment
    {
        public string Name { get; set; }
        public bool HasMaps { get; set; }
        public bool HasUSB { get; set; } = true;
        public bool HasAuxillary { get; set; } = true;
        public bool HasCd { get; set; }
        public string CurrentPlayer { get; set; } = "CD Player";
    }
    class Cnstr
    {
        static void Main(string[] args)
        {
            car car = new car();
            
            car.Run();
        }
    }
}
