using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Wycieczka
    {
        [Required]
        [Key]
        public int IdW { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        public int TotalPoints { get; set; }

        [Required]
        public bool VerifStatus { get; set; }
/*        [Required]
        public int IdK { get; set; }
        public Ksiazeczka Book { get; set; }*/



    }

}
