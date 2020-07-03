using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.Write("Plato Büyüklüğü Giriniz: ");
            Plateau plateau = new Plateau(ValidationHelper.PlateauValidator());

            Console.Write("\n 1.Rover İniş Koordinatları ve Yönünü Giriniz: ");
            Rover rover1 = new Rover(ValidationHelper.LandingCoordinatesValidator(plateau));

            Console.Write("\n 1.Rover hareketi için yönleri giriniz: ");
            rover1.MovementControl(ValidationHelper.MovementInputValidator());

            Console.Write("\n 2.Rover İniş Koordinatları ve Yönünü Giriniz: ");
            Rover rover2 = new Rover(ValidationHelper.LandingCoordinatesValidator(plateau));

            Console.Write("\n 2.Rover hareketi için yönleri giriniz: ");
            rover2.MovementControl(ValidationHelper.MovementInputValidator());

            Console.WriteLine("\n 1. Rover Son Kordinat:" + rover1.ToString());
            Console.WriteLine("\n 2. Rover Son Kordinat:" + rover2.ToString());


            Console.ReadKey();
        }
    }
}
