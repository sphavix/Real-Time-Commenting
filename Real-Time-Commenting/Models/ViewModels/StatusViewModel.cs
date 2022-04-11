using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Real_Time_Commenting.Models.ViewModels
{
    public class StatusViewModel
    {
        [Key]
        public int StatusID { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string StatusName { get; set; }
    }
}