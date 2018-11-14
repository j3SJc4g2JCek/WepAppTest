using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiTest.Models
{
    // Normally this would be placed in either a service library or a model repository, but not in the web api by default
    public class TestModel
    {
        public int TestId { get; set; }

        [Required]
        [Range(.01, 99999999)]
        public decimal TestAmount { get; set; }

        [Required]
        [MaxLength(50)]
        public string TestName { get; set; }

        [MaxLength(500)]
        public string TestDescription { get; set; }
    }
}