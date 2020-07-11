using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.ViewModel
{
    public class AdVm
    {
        public string id { get; set; }
        public string userID { get; set; }
        public string title { get; set; }
        public string details { get; set; }
        public string type { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }
        public long space { get; set; }
        public List<BorderVm> border { get; set; } = new List<BorderVm>();

        public class BorderVm
        {
            public string direction { get; set; }
            public int length { get; set; }
            public int width { get; set; }
            public bool IsStreet { get; set; }

        }
    }
}
