using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWS40.Backend.Conways
{
    public class Cell
    {
        public bool IsAlive { get; set; }

        public bool UseRules(int nbrOfLivingNeighbours)
        {
            if (!IsAlive && nbrOfLivingNeighbours == 3)
            {
                return true;
            }

            if (IsAlive && nbrOfLivingNeighbours < 2)
            {
                return false;
            }

            if (IsAlive && (nbrOfLivingNeighbours == 2 || nbrOfLivingNeighbours == 3))
            {
                return true;
            }

            if (IsAlive && nbrOfLivingNeighbours > 3)
            {
                return false;
            }

            return false;
        }


        public Cell Copy()
        {
            var newCell = new Cell()
            {
                IsAlive = IsAlive,
            };

            return newCell;
        }
    }
}
