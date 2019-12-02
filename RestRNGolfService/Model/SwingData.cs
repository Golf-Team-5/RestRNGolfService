using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestRNGolfService.Model
{
    public class SwingData
    {
        public double SwingSpeed { get; set; }

        public SwingData(double swingSpeed)
        {
            SwingSpeed = swingSpeed;
        }

        public SwingData()
        {

        }

        public override string ToString()
        {
            return $"{nameof(SwingSpeed)}: {SwingSpeed}";
        }

    }
}
