using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingFutureCities
{
    // This class holds 3 renovationconcepts to be compared to each other
    public class Comparison
    {
        public RenovationConcept Linear { get; set; }
        public RenovationConcept Circular1 { get; set; }
        public RenovationConcept Circular2 { get; set; }

        public Comparison()
        {
            Linear = new Linear();
            Circular1 = new Circular(1);
            Circular2 = new Circular(2);
        }

    }
}
