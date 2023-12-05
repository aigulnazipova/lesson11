using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tymakov13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 13.2. В класс BankAccount добавлен индексатор для получения доступа к любому объекту BankTransaction.\n");
            BankAccount bankAccount1 = new BankAccount(100000, BankAccountType.Current);
            BankAccount bankAccount2 = new BankAccount(200000, BankAccountType.Savings);
            bankAccount1.Transfer(bankAccount2, 7000);
            bankAccount2.Withdraw(349, bankAccount1.Balance);
            BankTransaction financialTransaction = bankAccount1[0];
            Console.WriteLine("Нажмите Enter, чтобы перейти к следующей задаче.");
            Console.ReadKey();

            Console.WriteLine("Д/з 13.1. В классе Building все методы для заполнения и получения значений полей заменить на свойства.\n");
            Building building = new Building(50.5, 10, 100, 5);
            building.Print();
            Console.WriteLine("Нажмите Enter, чтобы перейти к следующей задаче.");
            Console.ReadKey();

            Console.WriteLine("Д/з 13.2. Создание класса для нескольких зданий.\n");
            SeveralBuildings buildings = new SeveralBuildings();
            Building building1 = buildings[2];
            Console.WriteLine($"Building Number: {building.BuildingNumber}");
            buildings[2] = new Building(200, 10, 40, 4);
            Console.WriteLine($"Building Number: {buildings[2].BuildingNumber}");
            Console.WriteLine("Нажмите Enter, чтобы перейти к следующей задаче.");
            Console.ReadKey();

           
        }
    }

}
