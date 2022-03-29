using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class NetflixInfoAPI
    {
        public List<ShowData> netflix { get; set; }

        public class ShowData
        {
            public int? show_id { get; set; }
            public string? type { get; set; }
            public string? title { get; set; }
            public string? director { get; set; }
            public string? country { get; set; }
            public string? date_added { get; set; }
            public int? release_year { get; set; }
            public string? rating { get; set; }
            public string? duration { get; set; }
            public string? listed_in { get; set; }
            public string? description { get; set; }
            public override string ToString()
            {
                return $"{rating}";
            }
        }
    }
}
