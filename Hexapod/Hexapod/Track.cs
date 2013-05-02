using System.Collections.Generic;

namespace Hexapod
{
    public class Track
    {
        public double Time { get; set; }
        public int StepCount { get; set; }
        public List<Position> Positions { get; set; }
    }
}
