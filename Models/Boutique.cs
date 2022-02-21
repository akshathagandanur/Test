using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBoutique.Models
{
    public class Boutique
    {

        public int BoutiqueId { get; set; }

        [Required(ErrorMessage="Boutiquename is required")]
        public string DColor { get; set; }

        [Required(ErrorMessage = "Dress is required")]
        public string DStyle { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public double DPrice { get; set; }
    }
}