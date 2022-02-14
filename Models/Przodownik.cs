using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Przodownik
    {
        [Required]
        [Key]
        public int NrLegitymacji { get; set; }
        public int IdT { get; set; }
        [ForeignKey("IdT")]
        public Turysta Person { get; set; }
    }

}
