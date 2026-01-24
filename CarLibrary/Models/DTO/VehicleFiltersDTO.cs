using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary.Models.DTO
{
    public class VehicleFiltersDTO
    {
        [Required]
        public string Voivodeship { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public bool? OnlyRegistered { get; set; }

        public int? Limit { get; set; }
    }

}
