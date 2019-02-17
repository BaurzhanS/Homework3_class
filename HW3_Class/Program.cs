using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HW3_Class
{
    partial class Car
    {
        static private bool isNew_;
        static private double km_driven_;

        private string model_;
        private string colour_;
        private double price_;
        private double engineVolume_;
        private bool hasWarranty_;
        private string owner_;

        public bool isNew { get; set; }
        public double km_driven { get; set; }

        public string model { get; set; }
        public string colour { get; set; }
        public double price
        {
            get
            {
                return price_;
            }
            set
            {
                if (value > 0)
                {
                    price_ = value;
                }
                else
                {
                    Console.WriteLine("Цена не может быть ноль или отрицательной!");
                }
            }
        }
        public double engineVolume {
            get
            {
                return engineVolume_;
            }
            set
            {
                if (value > 0)
                {
                    engineVolume_ = value;
                }
                else
                {
                    Console.WriteLine("Объем двигателя не может быть ниже нуля!");
                }
            }
        }
        public bool hasWarranty {
            get
            {
                return hasWarranty_;
            }
            set
            {
                hasWarranty_ = value;
            }
        }
        public string owner {
            get
            {
                return owner_;
            }
            set
            {
                owner_ = value;
            }
        }

        static Car() { }

        Car(): this("")
        {}
        Car(string model): this(model,"") {}

        Car(string model,string colour) : this(model, colour, 0.0) {}
        Car(string model, string colour, double price) : this(model, colour, price, 0.0) {}
        Car(string model, string colour, double price, double engineVolume)
            : this(model, colour, price, engineVolume,true) {}
        Car(string model, string colour, double price, double engineVolume, bool hasWarranty) 
            : this(model, colour, price, engineVolume, true,"") {}
        Car(string model, string colour, double price, double engineVolume, bool hasWarranty, string owner)
        {
            this.model = model;
            this.colour = colour;
            this.price = price;
            this.engineVolume = engineVolume;
            this.hasWarranty = hasWarranty;
            this.owner = owner;
        }

        public void drive_car(ref string owner)
        {
            Console.WriteLine("{0} Выберите команду: \n1-ехать\n2-остановиться\n3-повернуть вправо\n4-повернуть влево", owner);
            int command = int.Parse(Console.ReadLine());
            switch (command)
            {
                case 1:
                    Console.WriteLine("Автомобиль {0} едит", model);
                    break;
                case 2:
                    Console.WriteLine("Автомобиль {0} остановился", model);
                    break;
                case 3:
                    Console.WriteLine("Автомобиль {0} повернул направо", model);
                    break;
                case 4:
                    Console.WriteLine("Автомобиль {0} повернул налево", model);
                    break;
                default:
                    Console.WriteLine("Выберите действие");
                    break;
            }
        }

        public double CalculateLengthToLocation(double time_in_hrs, double speed)
        {

            double km_passed = 0.0;
            while (km_passed <= time_in_hrs*speed)
            {
                Console.Clear();
                km_passed += (time_in_hrs/100 * speed);
                Console.WriteLine("Вы проехали {0} километров",km_passed);
                Thread.Sleep(100);
            }
            return km_passed;
       
        }

        public void TuneCar(double money_at_hand=0)
        {
            double paint_cost = 50000.0;
            double wings_cost =100000.0;
            double disc_cost = 40000.0;
            double turbo_engine_cost = 300000.0;

            double available_cash = money_at_hand;
            
            while (available_cash>0) {
                Console.WriteLine("Выберите услугу из списка: ");
                Console.WriteLine("1. Покраска автомобиля {0}. Стоимость: {1}", model, paint_cost);
                Console.WriteLine("2. Установка задних крыльев на автомобиль {0}. Стоимость: {1}", model, wings_cost);
                Console.WriteLine("3. Установка вращающихся дисков на колеса" +
                            " автомобиля {0}. Стоимость: {1}", model, disc_cost);
                Console.WriteLine("4. Установка турбо двигателя на автомобиль {0}." +
                            " Стоимость: {1}", model, turbo_engine_cost);
                int select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        Console.WriteLine("Выберите цвет: ");
                        colour = Console.ReadLine();
                        available_cash = available_cash - paint_cost;
                        break;
                    case 2:
                        Console.WriteLine("Крылья будут установлены: ");
                        available_cash = available_cash - wings_cost;
                        break;
                    case 3:
                        Console.WriteLine("Диски будут установлены: ");
                        available_cash = available_cash - disc_cost;
                        break;
                    case 4:
                        Console.WriteLine("Турбо-двигатель будет установлен: ");
                        engineVolume += engineVolume + 2;
                        available_cash = available_cash - turbo_engine_cost;
                        break;
                    default:
                        Console.WriteLine("Выберите из списка");
                        break;
                }
                if (available_cash<0)
                {
                    Console.WriteLine("На Вашем счету недостаточно средств!");
                    return;
                }

                    Console.WriteLine("Остаток на Вашем счету: {0}",available_cash);
                Thread.Sleep(5000);
                Console.Clear();

            }

            
            

        }

        public double CalculatePriceForUsedCar(double km_driven,bool hasWarranty = true)
        {
            if (hasWarranty)
            {
                price = price - km_driven;
                Console.WriteLine("Price for the car is {0}", price);
                return price;

            }
            else
            {
                price = price - km_driven - (price * 0.2);
                Console.WriteLine("Price for the car is {0}", price);
                return price;
            }
            
           
        }

       

        static void Main(string[] args)
        {

            //Car c1 = new Car("Ferrari","red",20000000,6,true,"Михаил");
            //Car c2 = new Car("Bugatti", "orange", 19000000, 7, true,"Саша");
            //Car c3 = new Car("Lada", "white", 1000000, 2, false,"Талгат");
            //Car c4 = new Car("Toyota", "black", 3000000, 3, false,"Инокентий");
            //Car c5 = new Car("Land Cruiser", "grey", 6000000, 4, true,"Борис");
            //Car c6 = new Car("Audi", "blue", 8000000, 4, true,"Владимир");
            //Car[] cars = new Car[6];
            //cars[0] = c1;
            //cars[1] = c2;
            //cars[2] = c3;
            //cars[3] = c4;
            //cars[4] = c5;
            //cars[5] = c6;

            //foreach (Car car in cars)
            //{
            //    car.PrintCarInfo();
            //    Console.WriteLine();

            //}


        }
    }
}
