
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_v2_popawna
{
    //internal 
        class Program
    {
        public static IManager GetManager()          // wykorzystujemy do zapisu filemenager ktory sluzy do zapisu pliku txt // IManager tworzymy w odrebnej klasie i dziedziczymy w klasie bazy danych i zapisu do tekstu
        {
            return new CloudManagae();       // zeby zapisywała do bazy danych to trzeba zmienic filemanager na databasemanager i wypełnić jej kod, / generalnie zwraca interface
        }
        static void Main(string[] args)         // statyczna
        {
            var calculator = new Calculator<int>();


            Console.WriteLine("wpisz prosze dwie liczby dzielone enterem: ");

            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Wpisz prosze działania ktore chcesz wykonać ");
            Console.WriteLine("dostepne działania to: + - / ");
            var operation = Console.ReadLine();

            var result = default(int);

            switch (operation)
            {
                case "+":
                    {
                        result = calculator.Add(firstNumber, secondNumber);
                    }break;
                case "-":
                    {
                        result =  calculator.Sybstract(firstNumber, secondNumber);
                    }
                    break;
                case "*":
                    {
                        result = calculator.Multiplay(firstNumber, secondNumber);
                    }
                    break;
                case "/":
                    {
                        result = calculator.Divide(firstNumber, secondNumber);
                    }
                    break;
                
            }


            
            Console.WriteLine(result);
            var aperation = Console.ReadLine();






            // var myLamp = new Lamp(200, 100);
            //myLamp.LightItself();
            //var myLamp2 = new Lamp(300, 150); // dzięki pryvatnemu seterowi możemu nadać im wartość
            //myLamp2.Height = 1;   tylko jeżeli set dla niego będzie public
            //myLamp2.LightItself();
            //var manager = GetManager();         // zmienilismy na zwykly menager bo bierze funkcje z interfejsu
            // manager.SaveLamp(myLamp);
        }
    }
}
