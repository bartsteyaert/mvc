using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tuincentrum.Models
{
    public class PlantProperties
    {
        [Display(ResourceType =typeof(Resources.Teksten), Name ="LabelPrijs")]
        [Range(0,1000, ErrorMessageResourceType =typeof(Resources.Teksten), ErrorMessageResourceName ="RangePrijs")]
        public decimal VerkoopPrijs { get; set; }

        [ScaffoldColumn(false)]
        public int Levnr { get; set; }
        [ScaffoldColumn(false)]
        public Leverancier Leverancier { get; set; }
    }
}