using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class Wpis
    {
        [Required]
        [Key]
        public int IdWp { get; set; }
        public int IdO { get; set; }
        [ForeignKey("IdO")]
        public OdcinekTrasy Track { get; set; }
        public int IdTr { get; set; }
        [ForeignKey("IdTr")]
        public Trasa Route { get; set; }
    }

}
