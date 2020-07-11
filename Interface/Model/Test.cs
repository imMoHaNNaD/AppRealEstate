using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.Model
{
    public class Test
    {
        [Required(ErrorMessage ="not null")]
        public string MyProperty { get; set; }
        public string uu { get; set; }

    }
}
