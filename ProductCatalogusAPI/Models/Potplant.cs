using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogusAPI.Models
{
    public class Potplant
    {
        [Key]
        [MaxLength(13)]
        public string Code { get; set; }
        [MaxLength(50)]
        [Required]
        public string Naam { get; set; }
        [Required]
        public int Potmaat { get; set; }
        [Required]
        public int Planthoogte { get; set; }
        public string Kleur { get; set; }
        [Required]
        public string Productgroep { get; set; }
    }
}
