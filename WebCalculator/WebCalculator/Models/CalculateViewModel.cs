using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class CalculateViewModel
    {
        public bool Calculated { get; set; } = false;
        public int Result { get; set; }
        public string Expression { get; set; }
    }
}
