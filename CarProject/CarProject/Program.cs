using System;
using System.Collections.Generic;

namespace CarProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Car[] car = { new Car("Fiat", "126p", 1987, 25.2f, 645f, 33f),
            //              new Car("FSO", "Polonez Caro", 1995, 103f, 113f, 13.8f)
            //              new Car("FSO", "Syrena 105", 1957, 26f, 850f, 55f)};

            List<Car> Car = new List<Car>();
            Car.Add(new Car("FSO", "Polonez Caro", 1995, 103f, 113f, 13.8f));
            Car.Add(new Car("Fiat", "126p", 1987, 25.2f, 645f, 33f));
            Car.Add(new Car("FSO", "Syrena 105", 1957, 26f, 850f, 55f));

            Console.WriteLine("\n!!! Jeśli tabela nie wyświetla się poprawnie rozszerz okno !!!\n");

            Car[0].ListOfCars(Car);                                //Displays the list of cars
            Car[0].OnTheStreet(Car[0].ChoseCar(Car), Car);         //Navigation with logs
        }
    }
}
