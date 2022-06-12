using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class Quote
    {
        public Quotes USD { get; set; }
        public Quotes GBP { get; set; }
        public Quotes JPY { get; set; }
        public Quotes NZD { get; set; }
        public Quotes CAD { get; set; }
        public Quotes AUD { get; set; }
        public Quotes EUR { get; set; }
    }
}
