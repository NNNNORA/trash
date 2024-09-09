using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
{
    public class CustomConverter
    {
        public void Convert1(string v, out int r)
        {
            r = System.Convert.ToInt32(v);
        }

        public void Convert1(string v, out double r)
        {
            r = System.Convert.ToDouble(v);
        }

        public void Convert1(string v, out float r)
        {
            r = System.Convert.ToSingle(v);
        }

        public void Convert1(string v, out bool r)
        {
            r = System.Convert.ToBoolean(v);
        }
    }
}
