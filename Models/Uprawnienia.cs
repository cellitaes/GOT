using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Uprawnienia
    {
        [Required]
        [Key]
        public int IdU { get; set; }
        public int NrLegitymacji { get; set; }
        [ForeignKey("NrLegitymacji")]
        public Przodownik Leader { get; set; }
        public int IdL { get; set; }
        [ForeignKey("IdL")]
        public LancuchGorski MountRange { get; set; }
    }

}
