using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Practice
{
    public class CarDataAPI
    {
        public string FirstName { get; set; }

        public string LastName  {get; set;}

        public string Make      {get; set;}

        public string Model     {get; set;}

        public int Year      {get; set;}

        public string Color     {get; set;}

        public CarDataAPI()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            Make = String.Empty;
            Model = String.Empty;
            Year = 0;
            Color = String.Empty;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} has {Make} {Model} made in {Year}";
        }
    }
}
            