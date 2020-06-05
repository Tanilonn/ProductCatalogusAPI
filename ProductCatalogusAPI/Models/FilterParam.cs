using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogusAPI.Models
{
    public class FilterParam
    {
        public string Naam { get; set; }
        public int? MinMaat { get; set; }
        public int? MaxMaat { get; set; }
        public string Kleur { get; set; }
        public string Productgroep { get; set; }

    }
}
