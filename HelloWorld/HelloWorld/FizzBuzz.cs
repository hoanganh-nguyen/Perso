using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class FizzBuzz
    {
        public string GetFizzBuzz(int i)
        {
            StringBuilder sb = new StringBuilder();
            if (i % 15 == 0)
            {
                return "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                return "Fizz";
            }
            else if (i % 5 == 0)
            {
                return "Buzz";
            }
            return i.ToString();
        }
    }
}
