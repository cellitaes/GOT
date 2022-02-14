using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class LancuchGorski
    {
        [Required]
        [Key]
        public int IdL { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }

}
