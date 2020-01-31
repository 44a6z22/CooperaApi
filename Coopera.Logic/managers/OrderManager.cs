using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coopera.Logic.managers
{
    public static class OrderManager
    {

        public static float Total(IEnumerable<float> numbers )
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
