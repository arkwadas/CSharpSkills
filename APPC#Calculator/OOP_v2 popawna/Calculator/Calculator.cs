using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_v2_popawna
{
    class Calculator<T>             //klasa generyczna nazywa sie ja jako T
        //where T : IManager          // dzieki klauzuli where mozemy dziedziczyc interfejsy
    {
        public Calculator()
        {
            var example = default(T);
            var isInt = (example is int);
            var isFloat = (example is float);
            var isDouble = (example is double);

            //example.SaveLamp()        to uzyskujemy dzieki where powyzej

            if (isInt)
            {

            }
            else if (isFloat)
            {

            }
            else if (isDouble)
            {

            }
            else
            {
                Console.WriteLine("Zainicjowano kalkulator niepoprawnie");
            }

        }
        public T Add(T first, T second)
        {
            dynamic firstNumber = (dynamic)first;
            dynamic secendNumber = (dynamic)second;
            return firstNumber + secendNumber;
        }
        public T Sybstract(T first, T second)
        {
            dynamic firstNumber = (dynamic)first;
            dynamic secendNumber = (dynamic)second;
            return firstNumber - secendNumber;
        }
        public int Multiplay(T first, T second)
        {
            dynamic firstNumber = (dynamic)first;
            dynamic secendNumber = (dynamic)second;
            return firstNumber * secendNumber;
        }
        public int Divide(T first, T second)
        {
            dynamic firstNumber = (dynamic)first;
            dynamic secendNumber = (dynamic)second;
            return firstNumber / secendNumber;
        }
    }
}
