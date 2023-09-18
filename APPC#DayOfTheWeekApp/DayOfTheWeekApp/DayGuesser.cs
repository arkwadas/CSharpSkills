using System;
using System.Collections.Generic;
using System.Text;
using DayOfTheWeekApp.Core;

namespace DayOfTheWeekApp
{
    public class DayGuesser
    {
        public DayCalculator Calculator { get; set; }

        public DateTimeOffset UserDateOfBirth { get; set; }

        public DayOfTheWeek UserDayOfTheWeek { get; set; }


        public void IntroduceTheApplication()
        {
            Console.WriteLine("Hey, wylicze dzień tygodnia na podstawie Twojej daty urodzenia.");
            Calculator = new DayCalculator();
        }


        public void AskUserForTheirDateOfBirth()
        {
            Console.WriteLine("Podaj prosze swoją date urodzenia: ");
            var userDate = Console.ReadLine();
            
            var succed = DateTimeOffset.TryParse(userDate, out var date);

            if (succed)
            {
                UserDateOfBirth = date;
                return;
            }

            Console.WriteLine("format daty był złyu. Prosze go podać w dd/MissingMemberException/yyyy");
            AskUserForTheirDateOfBirth();
        }

        public void CalculateDayOfTheWeek()
        {
            if (UserDateOfBirth == null)
            {
                Console.WriteLine("Próbowano obliczyc dzien tygodnia bez podania daty urodzewnia");
                return;
            }
            UserDayOfTheWeek = Calculator.CalculateDayOfTheWeek(UserDateOfBirth);
        }

        public void PrintDayOfTheWeek()
        {
            Console.WriteLine("Obliczony dzień tygodnia to: " + UserDayOfTheWeek.ToPolishString());

        }

    }
}
