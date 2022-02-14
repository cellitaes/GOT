using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Punkt
    {
        [Required]
        [Key]
        public int IdP { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public double Height { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int IdL { get; set; }
        [ForeignKey("IdL")]
        public LancuchGorski MountRange { get; set; }
    }
}
