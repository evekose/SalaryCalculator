using System;

namespace SalaryCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int grossSalary = 0; //brutopalk

            Console.WriteLine("Please enter your gross salary: ");
            grossSalary = Convert.ToInt32(Console.ReadLine());

            if (grossSalary >= 500 && grossSalary <= 1200) //aastatulu kuni 14400eur aastas; maksuvaba 6000 aastas
            {
                SalaryIsBetween500And1200(grossSalary);
            }
            if (grossSalary >= 1201 && grossSalary <= 2099) 
                // aastatulu 14400 kuni 25200; maksuvaba arvutamise valem = 500 - 0.55556 x (tulu - 1200)
            {
                SalaryIsBetween1201And2099(grossSalary);
            }
            if (grossSalary >= 2100) //aastatulu üle 25200; maksuvaba tulu on 0
            {
                SalaryIsAbove2100(grossSalary);
            }


                
        }
        public static void SalaryIsBetween500And1200(double grossSalary)
        {
            double mandatoryFundedPension = grossSalary * 0.02; //kohustuslik kogumispension 2%
            double unemploymentInsurancePremium = grossSalary * 0.016; //tööstuskindlustusmakse 1,6%
            double incomeTax = (grossSalary - 500 - mandatoryFundedPension - unemploymentInsurancePremium) * 0.2; //tulumaks 20%
            double netSalary = grossSalary - mandatoryFundedPension - unemploymentInsurancePremium - incomeTax;
            Console.WriteLine($"Your net salary is {netSalary}"); //netopalk
        }

        public static void SalaryIsBetween1201And2099(double grossSalary)
        {
            double mandatoryFundedPension = grossSalary * 0.02;
            double unemploymentInsurancePremium = grossSalary * 0.016;
            double taxFreeIncome = 500 - 0.55556 * (grossSalary - 1200); // tulumaksuvabastus
            double incomeTax = (grossSalary - mandatoryFundedPension - unemploymentInsurancePremium - taxFreeIncome) * 0.2;
            double netSalary = grossSalary - mandatoryFundedPension - unemploymentInsurancePremium - incomeTax;
            Console.WriteLine($"Your net salary is {netSalary}");
        }

        public static void SalaryIsAbove2100(double grossSalary)
        {
            double mandatoryFundedPension = grossSalary * 0.02;
            double unemploymentInsurancePremium = grossSalary * 0.016;
            double incomeTax = (grossSalary - mandatoryFundedPension - unemploymentInsurancePremium) * 0.2;
            double netSalary = (grossSalary - mandatoryFundedPension - unemploymentInsurancePremium) - incomeTax;
            Console.WriteLine($"Your net salary is {netSalary} ");
        }
    }
}
