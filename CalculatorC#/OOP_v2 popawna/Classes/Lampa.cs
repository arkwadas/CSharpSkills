using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_v2_popawna
{
    class Lamp : Item
    {
        // Funkcja  1 gdy tworzymy fiunkcje publick to możemy z niej korzystać w innej klasie
        //Finckja 2 gdy static
        //
        private int power; // konwencja jest taka że z małej i śrendikiem tworzymy takie zmienne które są z założenia pryvatne
        public int Power    // w geterach i seterach możemy dopisać ich dostępnośc np privet. Get to np Power.Height a ser to Powe.Height = 1;i wteyd nic nie zrobimy w programie z nimi
            // Tworzymy logikę!!!!!!!!!!!!!!!!!! \/
        {
            get    // zamiast średników mogą być klamry, get musi cos zwrócić
            {
                return power;
            }
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Próbowano ustawić nieprawidłwą wartość mocy lampy");
                    return;
                }
                power = value;
            }
        }      
        public void LightItself()       // To jest nasza funkcja!! :)
        {
            Console.WriteLine(Height);
            Console.WriteLine(Power);
        }   // !!!!!!! Tworzenie konsturktorów cdtr +2x TAB !!!!!!!
        public Lamp(int height, int power)       // konsturktor!! możemy w nim wymusić od razu podanie np wysokości i podanie mocy
        {
            Height = height;   // dzięki ustawieniu seta na protected możemy tego użyć :) 
            Power = power;
        }
    }
}
