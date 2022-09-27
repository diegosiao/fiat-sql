using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slink.DataAnnotations
{
    public class GreaterThanAttribute : Attribute
    {
        public double Value { get; set; }

        public GreaterThanAttribute()
        {

        }

        public GreaterThanAttribute(double value)
        {
            Value = value;
        }
    }
}
