using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Turysta
    {
        [Required]
        [Key]
        public int IdT { get; set; }
        [Required]
        [MaxLength(20)]
        public string Login { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        //public int IdK { get; set; }
        [Required]
        [MaxLength(6)]
        public string PostCode { get; set; }
        [Required]
        [MaxLength(8)]
        public string City { get; set; }
        [Required]
        [MaxLength(20)]
        public string Street { get; set; }
        [Required]
        public int AppartNr { get; set; }
        public int FlatNr { get; set; }
    }

}
