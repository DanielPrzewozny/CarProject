using System;
using System.Collections.Generic;

namespace CarProject
{
    public class Car
    {

        private string _make;
        private string _model;
        private int _year;
        private float _power;
        private float _weight;
        private float _acceleration;

        public bool isRunning;
        public bool isMoving;

        public string Make { get => _make; set { _make = value; } }
        public string Model { get => _model; set { _model = value; } }
        public int Year { get => _year; set { _year = value; } }
        public float Power { get => _power; set { _power = value; } }
        public float Weight { get => _weight; set { _weight = value; } }
        public float Acceleration { get => _acceleration; set { _acceleration = value; } }

        public Car() { }
        public Car(string make, string model, int year, float power, float weight, float acceleration)
        {

            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Power = power;
            this.Weight = weight;
            this.Acceleration = acceleration;
        }

        #region ListOfCars
        public void ListOfCars(List<Car> Car)
        {
            DrawTable.tableWidth = 100;
            DrawTable.PrintLine();
            DrawTable.PrintRow(true, "Id", "Marka", "Model", "Rok", "Moc (KM)", "Masa własna (kg)", "Przyspieszenie do 100km/h (s)");
            DrawTable.PrintLine();
            int count = 1;
            foreach (var car in Car)
            {
                DrawTable.PrintRow(true, count.ToString(), car.Make, car.Model, car.Year.ToString(), car.Power.ToString(), car.Weight.ToString(), car.Acceleration.ToString());

                count++;
            }
            DrawTable.PrintRow(true, "", "", "", "", "", "", "");
            DrawTable.PrintLine();
        }
        #endregion

        #region ChoseCar
        public int ChoseCar(List<Car> Car)
        {
            int carNum = 0;
            Console.WriteLine("\n\nWybierz samochód: ");
            while (!int.TryParse(Console.ReadLine(), out carNum) || carNum < 1 || carNum > 3)
            {
                Console.WriteLine("Wybierz jeszcze raz (id 1-3)! \n");
            }
            carNum = carNum - 1;
            return carNum;
        }
        #endregion

        //Navigation
        #region OnTheStreet 
        public void OnTheStreet(int carNum, List<Car> Car)
        {
            Console.WriteLine("\nWybrano : {0} {1} z {2} roku\n", Car[carNum].Make, Car[carNum].Model, Car[carNum].Year, Car[carNum].Acceleration);
            Console.WriteLine("Wybierz opcję za pomocą klawiszy: \n" +
                              "[E] Uruchom silnik\n" +
                              "[Q] Wyłącz silnik\n" +
                              "[W] Ruszaj w drogę\n" +
                              "[S] Zatrzymaj samochód\n" +
                              "[F] Sprawdź najszybszy samochód\n" +
                              "[ESC] Wyjdź\n");

            #region DrawTable
            DrawTable.tableWidth = 77;
            DrawTable.PrintLine();
            DrawTable.tableWidth = 15;
            DrawTable.PrintRow(false, "Czas");
            DrawTable.tableWidth = 60;
            DrawTable.PrintRow(true, $"({Car[carNum].Make} {Car[carNum].Model}) Log:");
            DrawTable.tableWidth = 77;
            DrawTable.PrintLine();
            #endregion 

            ConsoleKeyInfo info;
            do
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.E)
                {
                    StartEngine();
                }
                if (info.Key == ConsoleKey.Q)
                {
                    StopEngine();
                }
                if (info.Key == ConsoleKey.W)
                {
                    Move();
                }
                if (info.Key == ConsoleKey.S)
                {
                    Stop();
                }
                if (info.Key == ConsoleKey.F)
                {
                    Car carFastest = Car[TheFastest(Car)];
                    Console.WriteLine($"\n\n- Najszybszy samochód to {carFastest.Make} {carFastest.Model} z {carFastest.Year} z przyspieszeniem {carFastest.Acceleration} (s) do 100km/h");
                    List<Car> Fastest = new List<Car>();
                    Fastest.Add(carFastest);
                    ListOfCars(Fastest);
                }
            } while (info.Key != ConsoleKey.Escape);
        }
        #endregion 

        #region StartEngine
        public void StartEngine()
        {
            if (!isRunning && !isMoving)
            {
                isRunning = isRunning ? false : true;
                Log($" - Uruchomiono silnik");
            }
            else { Log($" - Silnik został już wcześniej uruchomiony"); }
        }
        #endregion

        #region StopEngine
        public void StopEngine()
        {
            if (isRunning && !isMoving)
            {
                isRunning = isRunning ? false : true;
                Log($" - Wyłączono silnik");
            }
            else if (isRunning && isMoving) { Log($" - Nie wyłączaj silnika gdy samochód jest w ruchu"); }
            else { Log($" - Silnik został już wcześniej wyłączony"); }
        }
        #endregion

        #region Move
        public void Move()
        {
            if (!isMoving && isRunning)
            {
                isMoving = isMoving ? false : true;
                Log($" - Samochód jest w ruchu");
            }
            else if (isMoving && isRunning) Log($" - Samochód jest w ruchu");
            else if (!isRunning) Log($" - W pierwszej kolejności uruchom silnik");
        }
        #endregion

        #region Stop
        public void Stop()
        {
            if (isMoving)
            {
                isMoving = isMoving ? false : true;
                Log($" - Samochód zatrzymał się");
            }
            else { Log($" - Samochód zatrzymał się już wcześniej i stoi w miejscu"); }
        }
        #endregion

        #region TheFastest
        public int TheFastest(List<Car> Car)
        {
            float mn = Car[0].Acceleration;
            int numCarmn = 0;

            for (int i = 1; i < Car.Count; i++)
            {
                if (Car[i].Acceleration < mn)
                {
                    mn = Car[i].Acceleration;
                    numCarmn = i;
                }
            }
            return numCarmn;
        }
        #endregion

        #region Log
        public void Log(string events)
        {
            DateTime localDate = DateTime.Now;
            DrawTable.tableWidth = 15;
            DrawTable.PrintRow(false, localDate.ToString("hh:mm:ss"));
            DrawTable.tableWidth = 60;
            DrawTable.PrintRow(true, events);
        }
        #endregion

    }
}
