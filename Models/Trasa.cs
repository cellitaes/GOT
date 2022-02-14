using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Trasa
    {
        [Required]
        [Key]
        public int IdTr { get; set; }
        public int IdW { get; set; }
        [ForeignKey("IdW")]
        public Wycieczka Trip { get; set; }
    }

}
