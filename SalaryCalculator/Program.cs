using System;

namespace SalaryCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int GrossSalary = 0; //brutopalk

            Console.WriteLine("Please enter your gross salary: ");
            GrossSalary = Convert.ToInt32(Console.ReadLine());

            if (GrossSalary >= 500 && GrossSalary <= 1200) //aastatulu kuni 14400eur aastas; maksuvaba 6000 aastas
            {
                Method1(GrossSalary);
            }
            if (GrossSalary >= 1201 && GrossSalary <= 2099) 
                // aastatulu 14400 kuni 25200; maksuvaba arvutamise valem = 500 - 0.55556 x (tulu - 1200)
            {
                Method2(GrossSalary);
            }
            if (GrossSalary >= 2100) //aastatulu üle 25200; maksuvaba tulu on 0
            {
                Method3(GrossSalary);
            }


                
        }
        static void Method1(double GrossSalary)
        {
            double MandatoryFundedPension = GrossSalary * 0.02; //kohustuslik kogumispension 2%
            double UnemploymentInsurancePremium = GrossSalary * 0.016; //tööstuskindlustusmakse 1,6%
            double IncomeTax = (GrossSalary - 500 - MandatoryFundedPension - UnemploymentInsurancePremium) * 0.2; //tulumaks 20%
            double Method1 = GrossSalary - MandatoryFundedPension - UnemploymentInsurancePremium - IncomeTax;
            Console.WriteLine("Your net salary is: " + Method1); //netopalk
        }

        static void Method2(double GrossSalary)
        {
            double MandatoryFundedPension = GrossSalary * 0.02;
            double UnemploymentInsurancePremium = GrossSalary * 0.016;
            double TaxFreeIncome = 500 - 0.55556 * (GrossSalary - 1200); // tulumaksuvabastus
            double IncomeTax = (GrossSalary - MandatoryFundedPension - UnemploymentInsurancePremium - TaxFreeIncome) * 0.2;
            double Method2 = GrossSalary - MandatoryFundedPension - UnemploymentInsurancePremium - IncomeTax;
            Console.WriteLine("Your net salary is: " + Method2);
        }

        static void Method3(double GrossSalary)
        {
            double MandatoryFundedPension = GrossSalary * 0.02;
            double UnemploymentInsurancePremium = GrossSalary * 0.016;
            double IncomeTax = (GrossSalary - MandatoryFundedPension - UnemploymentInsurancePremium) * 0.2;
            double Method3 = (GrossSalary - MandatoryFundedPension - UnemploymentInsurancePremium) - IncomeTax;
            Console.WriteLine("Your net salary is: " + Method3);
        }
    }
}
