using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Models
{
    public class OdcinekTrasy
    {
        [Key]
        public int IdO { get; set; }
        [Required]
        [MaxLength(30)]
        public string Trail { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double Length { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double HeightDiff { get; set; }

        [Required]
        [Range(1,30)]
        public int Points { get; set; }
        [Required]
        public int PointStartId { get; set; }
        [ForeignKey("PointStartId")]
        public Punkt PointStart { get; set; }
        [Required]
        public int PointEndId { get; set; }
        [ForeignKey("PointEndId")]
        public Punkt PointEnd { get; set; }


    }

}
