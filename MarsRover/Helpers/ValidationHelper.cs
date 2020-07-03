using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class ValidationHelper
    {

        public static List<int> PlateauValidator()
        {
            var result = false;
            List<int> plateauLimits = new List<int>();

            while (!result)
            {
                var limits = Console.ReadLine().Split(' ').ToList();
                if (limits.Count == 2 && limits[0].All(char.IsDigit) && limits[1].All(char.IsDigit))
                {
                    result = true;
                    plateauLimits.Add(Convert.ToInt32(limits[0]));
                    plateauLimits.Add(Convert.ToInt32(limits[1]));
                }
                else
                {
                    Console.Write("Lütfen plato sınırları için 2 adet sayıyı aralarında boşluk bırakarak giriniz!\n Plato Büyüklüğü Giriniz : ");
                }
            }

            return plateauLimits;

        }

        public static List<string> LandingCoordinatesValidator(Plateau p)
        {
            var result = false;
            List<string> landingCoordinatesAndDirection = new List<string>();

            while (!result)
            {
                var landingCoordinates = Console.ReadLine().Split(' ').ToList();

                if (landingCoordinates.Count == 3
                    && landingCoordinates[0].All(char.IsDigit)
                    && landingCoordinates[1].All(char.IsDigit)
                    && landingCoordinates[2].All(char.IsLetter)
                    && Enum.IsDefined(typeof(Direction), landingCoordinates[2]))
                {
                    int landingX = Convert.ToInt32(landingCoordinates[0]);
                    int landingY = Convert.ToInt32(landingCoordinates[1]);

                    if (landingX < Plateau.X && landingY < Plateau.Y)
                    {
                        landingCoordinatesAndDirection.Add(landingCoordinates[0]);
                        landingCoordinatesAndDirection.Add(landingCoordinates[1]);
                        landingCoordinatesAndDirection.Add(landingCoordinates[2]);

                        result = true;
                    }
                    else
                    {
                        Console.Write("İniş yapılacak koordinatlar Plato sınırları dışında!\nRover İniş Koordinatları ve Yönünü Giriniz: ");
                    }

                }
                else
                {
                    Console.Write("Lütfen iniş koordinatları için 2 adet sayı ve 1 adet yön bilgisini aralarında boşluk bırakarak giriniz!\nRover İniş Koordinatları ve Yönünü Giriniz: ");
                }
            }

            return landingCoordinatesAndDirection;

        }

        public static string MovementInputValidator()
        {
            var result = false;
            var movementDirections = "";

            while (!result)
            {
                movementDirections = Console.ReadLine();

                foreach (var item in movementDirections.ToUpper())
                {
                    if (string.IsNullOrEmpty(item.ToString()) || char.IsDigit(item))
                    {
                        Console.WriteLine("Boş veya sayı girilemez.");                    }
                    else
                    {
                        if ((item=='L') || (item=='M') || (item=='R'))
                        {
                            result = true;
                        }
                        else
                        {
                            Console.Write("Hareket yönü sadece L,M,R karakterlerini içerebilir! \n Rover hareketi için yönleri tekrar giriniz!");
                            break;
                        }
                        
                    }

                }

            }

            return movementDirections;
        }

        public static KeyValuePair<bool,string> LastPositionOutOfBoundsValidator(int xCoordinate, int yCoordinate)
        {
            var plateauBoundary = Plateau.GetPlateauBoundries();

            if (xCoordinate > plateauBoundary[0] || yCoordinate > plateauBoundary[1] || xCoordinate < 0 || yCoordinate < 0)
            {
                return new KeyValuePair<bool,string>(false,"Rover plato sınırları dışına çıktı!");
            }

            return new KeyValuePair<bool, string>(true, "");
        }

    }
}
