using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductCatalogusAPI.Models
{
    public class SortParam
    {
        
        public Order OrderBy { get; set; }
    }

    public enum Order
    {
        Naam = 0,
        Naam_Aflopend = 1,
        Planthoogte = 2,
        Planthoogte_Aflopend = 3,
        Groep = 4,
        Groep_Aflopend = 5,
        Potmaat = 6,
        Potmaat_Aflopend = 7
    }
}
