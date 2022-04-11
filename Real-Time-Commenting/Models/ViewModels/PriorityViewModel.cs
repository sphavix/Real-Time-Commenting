using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Real_Time_Commenting.Models.ViewModels
{
    public class PriorityViewModel
    {
        [Key]
        public int PriorityID { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string PriorityName { get; set; }
    }
}