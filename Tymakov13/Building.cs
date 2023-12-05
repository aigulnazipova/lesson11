using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tymakov13
{
    internal class Building
    {
        private static int LastBuildingNumber = 0;
        private double height;
        private int floors;
        private int apartments;
        private int entrances;
        internal int BuildingNumber { get; private set; }
        /// <summary>
        /// Свойство для чтения и заполнения поля height.
        /// </summary>
        public double Height 
        {
            get
            { 
                return height;
            }
            set
            {
                height = value;
            }
                
        }
        /// <summary>
        /// Свойство для чтения и заполнения поля floors.
        /// </summary>
        public int Floors
        {
            get
            {
                return floors;
            }
            set
            {
                floors = value;
            }

        }
        /// <summary>
        /// Свойство для чтения и заполнения поля apartments.
        /// </summary>
        public int Apartments
        {
            get
            {
                return apartments;
            }
            set
            {
                apartments = value;
            }

        }
        /// <summary>
        /// Свойство для чтения и заполнения поля entrances.
        /// </summary>
        public int Entrances
        {
            get
            {
                return entrances;
            }
            set
            {
                entrances = value;
            }

        }
        
        /// <summary>
        /// Конструктор, который создает новый экземпляр класса и заполняет его данными.
        /// </summary>
        public Building(double height, int floors, int apartments, int entrances)
        {
            BuildingNumber = GenerateBuildingNumber();
            Height = height;
            Floors = floors;
            Apartments = apartments;
            Entrances = entrances;
        }

        /// <summary>
        /// Конструктор, который создает новый экземпляр класса и заполняет его данными.
        /// </summary>
        public Building()
        {
            BuildingNumber = GenerateBuildingNumber();
        }

        /// <summary>
        /// Данный метод генерирует уникальный номер здания.
        /// </summary>
        private static int GenerateBuildingNumber()
        {
            LastBuildingNumber++;
            return LastBuildingNumber;
        }

        /// <summary>
        /// Данный метод считает высоту этажа здания.
        /// </summary>
        public double FloorHeight
        {
            get { return Height / Floors; }
        }

        /// <summary>
        /// Данный метод считает количество квартир в пролете.
        /// </summary>
        public int ApartmentsPerEntrance
        {
            get { return Apartments / Entrances; }
        }

        /// <summary>
        /// Данный метод считает количество квартир на этаже.
        /// </summary>
        public int ApartmentsPerFloor
        {
            get { return Apartments / Floors; }
        }
        /// <summary>
        /// Данный метод выводит информацию о здании на консоль.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Номер дома: {BuildingNumber}\nВысота: {Height} м\nКол-во этажей: {Floors}; ");
        }
    }
}
