using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Model.AD
{
    public class ADCreateModel
    {
        [Required]
        public string userID { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string details { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string Long { get; set; }
        [Required]
        public string Lat { get; set; }
        [Required]
        public long space { get; set; }
        [Required]
        public List<BorderCreate> border { get; set; } = new List<BorderCreate>();

        public class BorderCreate
        {
            [Required]
            public string direction { get; set; }
            [Required]
            public int length { get; set; }
            [Required]
            public int width { get; set; }
            [Required]
            public bool IsStreet { get; set; }

        }
    }
}
