using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_Class
{
    partial class Car
    {
        public void PrintCarInfo()
        {
            Console.WriteLine("Модель автомобиля: {0}\nЦвет: {1}\nЦена: {2}\nОбъем двигателя: {3}\nВладелец: {4}",
                model, colour, price, engineVolume, owner);
            if (hasWarranty == true)
            {
                Console.WriteLine("Имеется гарантия");
            }
            else
            {
                Console.WriteLine("Без гарантии");
            }
        }
    }
}
