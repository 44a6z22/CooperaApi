using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coopera.Logic.managers
{
    class OrderManager
    {

        public float Total(IEnumerable<float> numbers )
        {
            float res = 0;

            foreach ( float n in numbers)
            {
                res += n; 
            }

            return res;
        }
    }
}
