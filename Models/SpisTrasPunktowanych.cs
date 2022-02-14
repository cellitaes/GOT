using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class SpisTrasPunktowanych
    {
        [Required]
        [Key]
        public int IdS { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        public int IdO { get; set; }
        [ForeignKey("IdO")]
        public OdcinekTrasy Track { get; set; }


    }

}
