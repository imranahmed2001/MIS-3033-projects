using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThronesQuotes
{
    public class GOTAPI
    {
     public string quote     { get; set; } 
     public string character { get; set; }

        public override string ToString()
        {
            return $"{character}: {quote}";
        }
    }
}
