using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tymakov14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 14.1. Использование предопределенного условного атрибута для условного выполнения кода.\n");
            BankAccount account3 = new BankAccount(1000, BankAccountType.Savings, "DEBUG_ACCOUNT");
            account3.DumpToScreen();
            Console.WriteLine("Нажмите Enter, чтобы перейти к следующей задаче.");
            Console.ReadKey();

            
            Console.WriteLine("Упражнение 14.2. Создание пользовательского атрибута DeveloperInfoAttribute.\n");
            foreach (Attribute attr in typeof(RationalNumber).GetCustomAttributes(false))
            {
                if (attr is DeveloperInfoAttribute)
                {
                    DeveloperInfoAttribute devAttr = attr as DeveloperInfoAttribute;
                    Console.WriteLine($"Создатель: {devAttr.DeveloperName}, дата создания: {devAttr.DevelopmentDate}\n");
                }
            }
            Console.WriteLine("Нажмите Enter, чтобы перейти к следующей задаче.");
            Console.ReadKey();
            
            
            Console.WriteLine("Д/з 14.1. Создание пользовательского атрибута, который позволяет хранить в метаданных класса BankAccount имя разработчика и название организации.\n");
            foreach (Attribute attr in typeof(BankAccount).GetCustomAttributes(false))
            {
                if (attr is DeveloperAndOrganisationInfoAttribute)
                {
                    DeveloperAndOrganisationInfoAttribute devAttr = attr as DeveloperAndOrganisationInfoAttribute;
                    Console.WriteLine($"Имя:{devAttr.DeveloperName}\nОрганизация:{devAttr.DevelopmentOrganisation}.\n");
                }
            }
            Console.ReadKey();
        }
    }
}
