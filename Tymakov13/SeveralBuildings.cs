using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tymakov13
{
    internal class SeveralBuildings
    {
        private Building[] buildings;

        public SeveralBuildings()
        {
            buildings = new Building[10];
            for (int i = 0; i < buildings.Length; i++)
            {
                buildings[i] = new Building();
            }
        }

        public Building this[int index]
        {
            get
            {
                if (index >= 0 && index < buildings.Length)
                {
                    return buildings[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
                }
            }
            set
            {
                if (index >= 0 && index < buildings.Length)
                {
                    buildings[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
                }
            }
        }
    }
}
