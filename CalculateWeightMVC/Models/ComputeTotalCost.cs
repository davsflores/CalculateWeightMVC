using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculateWeightMVC.Models
{
    public class ComputeTotalCost
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Weight must be greater than 0")]
        public int itemweight { get; set; }

        public decimal itemcost { get; set; }

        public decimal itemtotalcost { get; set; }

        //public List<WeightTable> weighttablelist { get; set; }

    }
}